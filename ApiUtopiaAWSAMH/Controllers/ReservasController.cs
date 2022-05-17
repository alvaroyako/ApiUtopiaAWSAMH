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
    public class ReservasController : ControllerBase
    {
        private RepositoryUtopia repo;

        public ReservasController(RepositoryUtopia repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public ActionResult<List<Reserva>> GetReservas()
        {
            List<Reserva> reservas = this.repo.GetReservas();
            return reservas;
        }

        [HttpGet]
        [Route("[action]/{nombre}")]
        public ActionResult<Reserva> FindReserva(string nombre)
        {
            return this.repo.FindReserva(nombre);
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult CrearReserva(Reserva reserva)
        {
            this.repo.CrearReserva(reserva);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize]
        public ActionResult UpdateReserva(Reserva reserva)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.EditarReserva(
                reserva.Nombre,
                reserva.Telefono,
                reserva.Email,
                reserva.Personas,
                reserva.Fecha,
                reserva.Hora
                );
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("[action]/{nombre}")]
        [Authorize]
        public ActionResult DeleteReserva(string nombre)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(json);
            if (usuario.Rol == "admin")
            {
                this.repo.DeleteReserva(nombre);
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
