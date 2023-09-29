using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.DTO;
using BussinessLogic.Services;
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
        public async Task<IList<CategoriaDTO>> GetCategorias()
        {
            IList<CategoriaDTO> categorias = await _service.GetAllCategorias();
            return categorias;
        }

        // POST api/values
        [HttpPost]
        [Route("/categorias")]
        public async Task<CategoriaDTO> PostCategoria([FromBody]CategoriaDTO categoria)
        {
            // _service.PostCategoria(categoria);

            CategoriaDTO cat = await _service.PostCategoria(categoria);
            return cat;
        }

     

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteCategoria(id);
        }
    }
}

