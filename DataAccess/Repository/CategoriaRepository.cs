using System;
using DataAccess.IRepository;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace DataAccess.Repository
{
    public class CategoriaRepository : GenericRepository<Categoria>, ICategoriaRepository
    {

        
        //que hace esta linea
        public CategoriaRepository(MydbContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Categoria>> GetAllCategoriasProductos()
        {
            //busco todas las categorias con el producto incluido
            return await _context.Categoria.Include(c => c.Producto).ToListAsync();
        }

        public Task<int> GetCantidadProductosByCategoria(int idCategoria)
        {
            //busco la categoria por id y cuento la cantidad de productos que tiene
            return _context.Categoria.Where(c => c.Id == idCategoria).Select(c => c.Producto.Count).FirstOrDefaultAsync();

        }
    }
}

