using Data;
using Data.UnitiWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EjercicioApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        readonly IUnitiWork UnitiWork;
        public CustomerController(IUnitiWork unitiWork)
        {
            UnitiWork = unitiWork;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{page}/{row}")]
        public IEnumerable<Customer> GetPag(int page,int row)
        {
            return UnitiWork.Customer.ListView(page, row);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
