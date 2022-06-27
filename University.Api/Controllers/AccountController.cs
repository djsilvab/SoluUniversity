using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using University.Logic.Dtos;

namespace University.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        /// <summary>
        /// metodo encargado de realizar la autenticacion
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            bool isCredentialValid = loginDto.Password.Equals("123456");//validar cn AD
            if (isCredentialValid)//autenticacion valida
            {
                var token = TokenGenerator.GenerateTokenJwt(loginDto.Username);
                return Ok(token);
            }
            else return Unauthorized();//status code 401
        }
    }
}
