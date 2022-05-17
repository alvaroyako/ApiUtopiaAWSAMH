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
    public class JuegosController : ControllerBase
    {
        private RepositoryUtopia repo;

        public JuegosController(RepositoryUtopia repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<List<Juego>> GetJuegos()
        {
            List<Juego> juegos = this.repo.GetJuegos();
            return juegos;
        }

        [HttpGet]
        [Route("[action]/{idjuego}")]
        public ActionResult<Juego> FindJuego(int idjuego)
        {
            return this.repo.FindJuego(idjuego);
        }

        [HttpGet]
        [Route("[action]/{nombrejuego}")]
        public ActionResult<Juego> BuscarJuegoNombre(string nombrejuego)
        {
            return this.repo.BuscarJuegoNombre(nombrejuego);
        }


        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public ActionResult CrearJuego(Juego juego)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.CrearJuego(juego);
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
        public ActionResult UpdateJuego(Juego juego)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.EditarJuego(
                juego.IdJuego,
                juego.Nombre,
                juego.Descripcion,
                juego.Categoria,
                juego.Precio,
                juego.Foto
                );
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("[action]/{idjuego}")]
        [Authorize]
        public ActionResult DeleteJuego(int idjuego)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.DeleteJuego(idjuego);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
