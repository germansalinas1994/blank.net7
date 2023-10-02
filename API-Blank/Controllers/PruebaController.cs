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

        //Instancio el service que vamos a usar
        private ServicePrueba _service;

        //Inyecto el service por el constructor
        public PruebaController(ServicePrueba service)
        {
            _service = service;
        }
        // GET: api/values

        //Metodo para traer todas las categorias
        [HttpGet]
        [Route("/categorias")]
        public async Task<IList<CategoriaDTO>> GetCategorias()
        {
            IList<CategoriaDTO> categorias = await _service.GetAllCategorias();
            return categorias;
        }

        // POST api/values

        //Metodo para insertar una categoria
        [HttpPost]
        [Route("/categorias")]
        public async Task<CategoriaDTO> PostCategoria([FromBody] CategoriaDTO categoria)
        {
            // _service.PostCategoria(categoria);

            CategoriaDTO cat = await _service.PostCategoria(categoria);
            return cat;
        }



        // PUT api/values/5
        //Metodo para editar una categoria
        [HttpPut("{id}")]
        public async Task<CategoriaDTO> Put(int id, [FromBody] string value)
        {
            CategoriaDTO categoriaEditada = await _service.EditarCategoria(id, value);
            return categoriaEditada;
        }

        // DELETE api/values/5
        //Metodo para eliminar una categoria, eliminacion fisica
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.DeleteCategoria(id);
        }

        //Metodo para buscar categorias por algun criterio GetByCriteria

        [HttpGet("/buscarCategoria")]
        public async Task<IList<CategoriaDTO>> BuscarCategorias([FromQuery] string descripcion)
        {
            IList<CategoriaDTO> categorias = await _service.BuscarCategorias(descripcion);
            return categorias;
        }
        
    }
}

