using ApiUtopiaAWSAMH.Helpers;
using ApiUtopiaAWSAMH.Models;
using ApiUtopiaAWSAMH.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private RepositoryUtopia repo;
        private HelperOAuthToken helper;

        public AuthController(RepositoryUtopia repo, HelperOAuthToken helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult Login(LoginModel model)
        {
            Usuario usuario = this.repo.ExisteUsuario(model.Email, model.Password);
            if (usuario == null)
            {
                return Unauthorized();
            }
            else
            {
                SigningCredentials credentials = new SigningCredentials(this.helper.GetKeyToken(), SecurityAlgorithms.HmacSha256);
                string jsonUsuario = JsonConvert.SerializeObject(usuario);
                Claim[] claims = new[]
                {
                    new Claim("UserData",jsonUsuario),
                };
                JwtSecurityToken token = new JwtSecurityToken(
                    claims: claims,
                    issuer: this.helper.Issuer,
                    audience: this.helper.Audience,
                    signingCredentials: credentials,
                    expires: DateTime.UtcNow.AddMinutes(30),
                    notBefore: DateTime.UtcNow
                    );
                return Ok(
                    new
                    {
                        response = new JwtSecurityTokenHandler().WriteToken(token)
                    });
            }
        }
    }
}
