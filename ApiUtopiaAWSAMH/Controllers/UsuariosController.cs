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
    public class UsuariosController : ControllerBase
    {
        private RepositoryUtopia repo;

        public UsuariosController(RepositoryUtopia repo)
        {
            this.repo = repo;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult RegistrarUsuario(Usuario usuario)
        {
            bool respuesta = this.repo.RegistrarUsuario(
                usuario.Nombre,
                usuario.Email,
                usuario.PasswordString,
                usuario.Imagen,
                "cliente"
                );
            if (respuesta == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }

        }

        [HttpGet]
        [Route("[action]/{idusuario}")]
        [Authorize]
        public ActionResult<Usuario> FindUsuario(int idusuario)
        {
            return this.repo.FindUsuario(idusuario);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public ActionResult<Usuario> PerfilUsuario()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string jsonUsuario = claims.SingleOrDefault(z => z.Type == "UserData").Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonUsuario);
            return usuario;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<Usuario> ExisteUsuario(string email, string password)
        {
            Usuario usu = this.repo.ExisteUsuario(email, password);
            if (usu != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
