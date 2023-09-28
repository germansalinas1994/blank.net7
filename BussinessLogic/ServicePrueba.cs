using System;
using BussinessLogic.DTO;
using DataAccess.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic
{
    public class ServicePrueba
    {


        private MydbContext _dbContext;

        public ServicePrueba(MydbContext mydbContext)
        {
            _dbContext = mydbContext;
        }


        public IList<CategoriaDTO> GetAllCategorias()
        {
            // List<Categoria> categoria = _dbContext.Categoria.Include(x => x.Producto).ToList();

            List<Categoria> categoria = _dbContext.Categoria.ToList();
            

            List<CategoriaDTO> categoriaDTO = categoria.Adapt<List<CategoriaDTO>>().ToList();

            foreach (var item in categoriaDTO)
            {
                int cantidadProductos = _dbContext.Producto.Where(x => x.IdCategoria == item.Id).Count();
                item.CantidadProductos = cantidadProductos;
            }

            return categoriaDTO;



        }

        public CategoriaDTO GetCategoriaById(int id)
        {

            Categoria categoria = _dbContext.Categoria.Find(id);
            // CategoriaDTO categoria = _dbContext.Categoria.Where(x => x.Id == id).FirstOrDefault().Adapt<CategoriaDTO>();



            if (categoria != null)
            {
                return categoria.Adapt<CategoriaDTO>();
            }
            else
            {
                throw new Exception("No se encontro la categoria");
            }
        }

        public void PostCategoria(CategoriaDTO categoria)
        {
            _dbContext.Categoria.Add(categoria.Adapt<Categoria>());
            _dbContext.SaveChanges();
        }
    }
}

