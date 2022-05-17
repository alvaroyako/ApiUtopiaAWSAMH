using ApiUtopiaAWSAMH.Models;
using ApiUtopiaAWSAMH.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlatosController : ControllerBase
    {
        private RepositoryUtopia repo;

        public PlatosController(RepositoryUtopia repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Plato>> GetPlatos()
        {
            List<Plato> platos = this.repo.GetPlatos();
            return platos;
        }

        [HttpGet]
        [Route("[action]/{idplato}")]
        public ActionResult<Plato> FindPlato(int idplato)
        {
            return this.repo.FindPlato(idplato);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public ActionResult CrearPlato(Plato plato)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.CrearPlato(plato);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }

        }

        [HttpPut]
        [Route("[action]")]
        [Authorize]
        public ActionResult UpdatePlato(Plato plato)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.EditarPlato(
                plato.IdPlato,
                plato.Nombre,
                plato.Descripcion,
                plato.Categoria,
                plato.Precio,
                plato.Foto
                );
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("[action]/{idplato}")]
        [Authorize]
        public ActionResult DeletePlato(int idplato)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.DeletePlato(idplato);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
