using System;
using System.Security.Claims;
using ComercioLocalBackEnd.Models;
using ComercioLocalBackEnd.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ComercioLocalBackEnd.Controllers
{

    [Authorize]
    [ApiController]
    [Route("v1/perfil")]
    public class PerfilController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromServices] IPerfilRepository repository)
        {
            var perfil = repository.FindByuser(new Guid(User.Identity.Name));
            if(perfil == null)
                return Unauthorized();
            perfil.Usuario.Senha = "";
            return Ok(perfil);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Perfil model, [FromServices] IPerfilRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            model.UsuarioId = new Guid(User.Identity.Name);

            var _perfil = repository.FindByuser(model.UsuarioId);
            
            if(_perfil == null){
                repository.Create(model);
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromServices] IPerfilRepository repository, [FromServices] IUsuarioRepository repositoryUsuario)
        {
            //TODO APAGAR PROMOÇÕES
            repository.DeleteByUser(new Guid(User.Identity.Name));
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Perfil model, [FromServices] IPerfilRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            repository.UpdateByUser(new Guid(User.Identity.Name), model);
            return Ok();
        }
    }
}