using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class RoleRegular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "67bb2e0b-c567-434b-8f37-cf985128f30e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "5f1a9e28-1012-4688-830e-a08d49fe7ff4", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3943f5d3-ff6f-4a31-bf8a-f3add26ca9ab", "AQAAAAEAACcQAAAAEHfOrbCx+uS1gBr0NfxvCbbT8bBe8x5bwwROqMs7X7KzfJYKgYF+wcfat9x4/QNmGA==", "b04a72c6-7c3e-424d-a806-96bd8b901add" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "4181e833-e827-4ab0-92d7-034dbf2899fe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8b79ad7a-077c-4a62-b373-5ccfcf6b890c", "AQAAAAEAACcQAAAAEHHa2at026RDLiJg2u2hlKv0yOhl2EUjyPWe9ihSGn9+VYtWs/ysZkhylAN2F51PyA==", "e79f518e-9690-47d9-a10c-99af468e8201" });
        }
    }
}
