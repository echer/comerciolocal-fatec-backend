using System;
using ComercioLocalBackEnd.Models;
using ComercioLocalBackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComercioLocalBackEnd.Controllers
{

    [Authorize]
    [ApiController]
    [Route("v1/usuario")]
    public class UsuarioController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromServices] IUsuarioRepository repository)
        {
            var usuario = repository.Read(new Guid(User.Identity.Name));
            usuario.Senha = "";
            return Ok(usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody] Usuario model, [FromServices] IUsuarioRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            repository.Create(model);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] UsuarioUpdate model, [FromServices] IUsuarioRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            repository.Update(new Guid(User.Identity.Name), model);
            return Ok();
        }
    }
}