using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic;
using BussinessLogic.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Blank.Controllers
{
    [Route("api/[controller]")]
    public class PruebaController : Controller
    {
        private ServicePrueba service;

        public PruebaController()
        {
            service = new ServicePrueba();
        }
        // GET: api/values
        [HttpGet]
        [Route("/categorias")]
        public IList<CategoriaDTO> GetCategorias()
        {
            IList<CategoriaDTO> categorias = service.GetAllCategorias();
            return categorias;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

