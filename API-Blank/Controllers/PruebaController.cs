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
        private ServicePrueba _service;

        public PruebaController(ServicePrueba service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        [Route("/categorias")]
        public IList<CategoriaDTO> GetCategorias()
        {
            IList<CategoriaDTO> categorias = _service.GetAllCategorias();
            return categorias;
        }

        // POST api/values
        [HttpPost]
        [Route("/categorias")]
        public void PostCategoria([FromBody]CategoriaDTO categoria)
        {
            _service.PostCategoria(categoria);
        }

        // GET api/values/5
        [HttpGet]
        [Route("/categorias/{id}")]
        //public CategoriaDTO GetCategoriaById(int id)
        //{
        //    CategoriaDTO categoria = service.GetCategoriaById(id);
        //    return categoria;
        //}

        // POST api/values
        //[HttpPost]
        //[Route("/categorias")]
        //public void ActualizarCategoria([FromBody]CategoriaDTO categoria)
        //{
        //    service.PostCategoria(categoria);
        //}

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

