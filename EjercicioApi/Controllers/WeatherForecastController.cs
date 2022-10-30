using Data;
using Data.UnitiWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjercicioApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class WeatherForecastController : ControllerBase
    {
        readonly IUnitiWork d;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitiWork D)
        {
            _logger = logger;
            d = D;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return d.Customer.GetList();
           
        }
    }
}
