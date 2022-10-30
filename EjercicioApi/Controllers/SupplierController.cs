using Data.UnitiWork;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class SupplierController : ControllerBase
    {
        readonly IUnitiWork UnitiWork;
        public SupplierController(IUnitiWork unitiWork)
        {
            UnitiWork = unitiWork;
        }
        // GET: api/<SupplierController>
        [HttpGet("{page:int}/{row:int}")]
        public IEnumerable<Supplier> GetPag(int page, int row)
        {
            throw new Exception("la base de ");
            return UnitiWork.Supplier.ListView(page, row);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public Supplier Get(int id)
        {
            return UnitiWork.Supplier.GetById(id);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post(Supplier  value)
        {
            
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
