using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ComercioLocalBackEnd.Models;
using ComercioLocalBackEnd.Models.ViewModels;
using ComercioLocalBackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ComercioLocalBackEnd.Controllers
{
    [ApiController]
    [Route("v1/login")]
    public class LoginController : ControllerBase
    {


        [HttpPost]
        public IActionResult Login([FromBody] PerfilLogin login, [FromServices] IUsuarioRepository repository, [FromServices] IPerfilRepository repositoryPerfil)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Usuario usuario = repository.Login(login.Email, login.Senha);

            if (usuario == null)
                return Unauthorized();

            usuario.Senha = "";

            return Ok(new{
                    usuario = usuario,
                    token = GenerateToken(usuario)
                });
        }

        private string GenerateToken(Usuario usuario){//, Perfil perfil){
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("UmTokenMuitoGrandeEDiferenteParaNinguemDescobrir");
            var descriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}