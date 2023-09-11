using System;
using BussinessLogic.DTO;
using DataAccess.Entities;
using Mapster;

namespace BussinessLogic
{
	public class ServicePrueba
	{
        private MydbContext _dbContext;

        public ServicePrueba()
        {
            _dbContext = new MydbContext();

        }

        public IList<CategoriaDTO> GetAllCategorias()
        {
            List<Categoria> resultado = _dbContext.Categoria.ToList();


            List<CategoriaDTO> categorias = resultado.Adapt<IList<CategoriaDTO>>().ToList();
            return categorias;
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

