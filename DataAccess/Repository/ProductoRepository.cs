using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.IRepository;
using DataAccess.Entities;

namespace DataAccess.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(MydbContext context) : base(context)
        {
        }

        // public IList<Producto> GetProductosByCategoria(int idCategoria)
        // {
        //     return _context.Productos.Where(p => p.IdCategoria == idCategoria).ToList();
        // }

        // public IList<Producto> GetProductosByCategoriaAndNombre(int idCategoria, string nombre)
        // {
        //     return _context.Productos.Where(p => p.IdCategoria == idCategoria && p.Nombre.Contains(nombre)).ToList();
        // }

        // public IList<Producto> GetProductosByNombre(string nombre)
        // {
        //     return _context.Productos.Where(p => p.Nombre.Contains(nombre)).ToList();
        // }

        // public IList<Producto> GetProductosByPrecio(decimal precio)
        // {
        //     return _context.Productos.Where(p => p.Precio == precio).ToList();
        // }

        // public IList<Producto> GetProductosByPrecioAndNombre(decimal precio, string nombre)
        // {
        //     return _context.Productos.Where(p => p.Precio == precio && p.Nombre.Contains(nombre)).ToList();
        // }

        // public IList<Producto> GetProductosByPrecioAndCategoria(decimal precio, int idCategoria)
        // {
        //     return _context.Productos.Where(p => p.Precio == precio && p.IdCategoria == idCategoria).ToList();
        // }

        
    }
}