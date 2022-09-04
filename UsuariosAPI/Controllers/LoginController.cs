using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosAPI.Data.Requests;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LogarUsuario(LoginRequest request)
        {
            var resultado = await _loginService.LogarUsuario(request);

            if (resultado.IsFailed)
                return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }

        [HttpPost("/Solicitar-reset")]
        public async Task<IActionResult> SolicitarResetSenhaUsuario(SolicitarResetRequest request)
        {
            Result resultado = await _loginService.SolicitarResetSenhaUsuario(request);

            if (resultado.IsFailed)
                return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }

        [HttpPost("/Efetuar-reset")]
        public async Task<IActionResult> ResetarSenhaUsuario(EfetuarResetRequest request)
        {
            Result resultado = await _loginService.SolicitarResetSenhaUsuario(request);

            if (resultado.IsFailed)
                return Unauthorized(resultado.Errors);

            return Ok(resultado.Successes);
        }
    }
}
