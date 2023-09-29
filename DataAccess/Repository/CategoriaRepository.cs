using System;
using DataAccess.IRepository;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {

        
        //que hace esta linea
        public CategoriaRepository(MydbContext mydbContext) : base(mydbContext)
        {
        }

        



        //public Task<IEnumerable<Categoria>> GetByDescripcion(string descripcion)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<Categoria>> GetByNombre(string nombre)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<long> GetCount()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<long> GetProductosByCategoria(int idCategoria)
        //{
        //    throw new NotImplementedException();
        //}

    }
}

