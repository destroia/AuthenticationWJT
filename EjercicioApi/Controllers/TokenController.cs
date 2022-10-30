using Data.UnitiWork;
using EjercicioApi.Authentication;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjercicioApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        readonly IUnitiWork UnitiWork;
        readonly ITokenProvider Token;
        public TokenController(IUnitiWork unitiWork, ITokenProvider token)
        {
            UnitiWork = unitiWork;
            Token = token;
        }
        // GET: api/<TokenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

      
        // POST api/<TokenController>
        [HttpPost]
        public JsonWebToken Post( User login)
        {
            //var user = UnitiWork.User.ValidatieUser(login.Email, login.Password);
            //if (user == null)
            //{
            //    return new JsonWebToken() { StatusCode = 404 };
            //}
            var token = new JsonWebToken()
            {
                Access_Token = Token.CreateToken(login, DateTime.UtcNow.AddHours(8)),
                Expires_In= 480,
                StatusCode = 200
            };
            
            return token;
        }

       
    }
}
