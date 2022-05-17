using ApiUtopiaAWSAMH.Models;
using ApiUtopiaAWSAMH.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private RepositoryUtopia repo;

        public ComprasController(RepositoryUtopia repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]/{idusuario}")]
        [Authorize]
        public ActionResult<List<Compra>> BuscarComprasUsuario(int idusuario)
        {
            List<Compra> compras = this.repo.BuscarCompras(idusuario);
            return compras;
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public ActionResult CreateCompra(Compra compra)
        {
            this.repo.CreateCompras(compra);
            return Ok();
        }
    }
}
