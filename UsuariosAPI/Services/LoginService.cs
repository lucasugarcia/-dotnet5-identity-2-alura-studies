using FluentResults;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Controllers;
using UsuariosAPI.Data.Requests;

namespace UsuariosAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<IdentityUser<int>> signInManager, TokenService tokenService)
        {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<Result> LogarUsuario(LoginRequest request)
        {
            var resultadoIdentity = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (resultadoIdentity.Succeeded)
            {
                var identityUser = _signInManager.UserManager.Users
                    .FirstOrDefault(u => u.NormalizedUserName == request.Username.ToUpper());

                var token = _tokenService.CreateToken(identityUser, _signInManager.UserManager.GetRolesAsync(identityUser)));

                return Result.Ok().WithSuccess(token.Value);
            }

            return Result.Fail("Login falhou");
        }

        public async Task<Result> SolicitarResetSenhaUsuario(SolicitarResetRequest request)
        {
            IdentityUser<int> identityUser = RecuperarUsuarioPorEmail(request.Email);

            if (identityUser != null)
            {
                var codigoDeRecuperacao = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(identityUser);

                return Result.Ok().WithSuccess(codigoDeRecuperacao);
            }

            return Result.Fail("Falha ao solicitar redefinção de senha");
        }

        private IdentityUser<int> RecuperarUsuarioPorEmail(string email)
        {
            return _signInManager.UserManager.Users
                .FirstOrDefault(u => u.NormalizedEmail == email.ToUpper());
        }

        public async Task<Result> ResetarSenhaUsuario(EfetuarResetRequest request)
        {
            var identityUser = RecuperarUsuarioPorEmail(request.Email);

            var resultadoIdentity = await _signInManager.UserManager.ResetPasswordAsync(identityUser, request.Token, request.Password);

            if (resultadoIdentity.Succeeded)
                return Result.Ok().WithSuccess("Senha redefinida com sucesso");

            return Result.Fail("Ocorreu um erro ao resetar senha do usuário!");
        }
    }
}
