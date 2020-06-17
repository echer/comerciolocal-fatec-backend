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
    [Route("v1/promocao/")]
    public class PromocaoController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get([FromServices] IPromocaoRepository repository,[FromServices]IPerfilRepository repositoryPerfil)
        {
            return Ok(repository.Find());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Promocao model, [FromServices] IPromocaoRepository repository, [FromServices]IPerfilRepository repositoryPerfil)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var _perfil = repositoryPerfil.FindByuser(new Guid(User.Identity.Name));
            if(_perfil == null)
                return Unauthorized();

            model.Perfil = _perfil;
            model.PerfilId = _perfil.Id;
            repository.Create(model);
            return Ok();
        }

        [HttpDelete]
        //[Route("{guidPromocao}")]
        public IActionResult Delete(string guidPromocao, [FromServices] IPromocaoRepository repository, [FromServices] IPerfilRepository repositoryPerfil)
        {

            var _perfil = repositoryPerfil.FindByuser(new Guid(User.Identity.Name));
            if(_perfil == null)
                return Unauthorized();
            
            repository.Delete(new Guid(guidPromocao), _perfil.Id);
            return Ok();
        }
    }
}