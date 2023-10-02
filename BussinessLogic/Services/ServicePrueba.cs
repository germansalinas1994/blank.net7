using System;
using System.Security.Cryptography.X509Certificates;
using BussinessLogic.DTO;
using DataAccess.IRepository;
using DataAccess.Entities;
using Mapster;

namespace BussinessLogic.Services
{
  public class ServicePrueba
    {
        //Instancio el UnitOfWork que vamos a usar
        private readonly IUnitOfWork _unitOfWork;

        //Inyecto el UnitOfWork por el constructor, esto se hace para que se cree un nuevo contexto por cada vez que se llame a la clase
        public ServicePrueba(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<CategoriaDTO>> GetAllCategorias()
        {
            IList<Categoria> categorias = await _unitOfWork.CategoriaRepository.GetAll();

            IList<CategoriaDTO> categoriaDTO = categorias.Adapt<IList<CategoriaDTO>>();

            foreach (var item in categoriaDTO)
            {
                // item.CantidadProductos = item.Producto.Count();

                item.CantidadProductos = await _unitOfWork.CategoriaRepository.GetCantidadProductosByCategoria(item.Id);
            }

            return categoriaDTO;

        }

        public async Task<CategoriaDTO> PostCategoria(CategoriaDTO categoria)
        {
            try
            {
                // Abre una transacción antes de realizar operaciones de base de datos
                await _unitOfWork.BeginTransactionAsync();

                Categoria categoriaEntity = categoria.Adapt<Categoria>();
                categoriaEntity = await _unitOfWork.CategoriaRepository.Insert(categoriaEntity);


                //lo rompo aproposito para probar que funcione el rollback

                await _unitOfWork.CommitAsync();

                return categoriaEntity.Adapt<CategoriaDTO>();
            }
            catch (Exception ex)
            {
                // Maneja la excepción y realiza un rollback en caso de error
                await _unitOfWork.RollbackAsync();
                throw ex;
            }
        }

        public async Task DeleteCategoria(int id)
        {
            bool borrado = await _unitOfWork.CategoriaRepository.Delete(id);
        }

        public async Task<CategoriaDTO> EditarCategoria(int id, string value)
        {

            await _unitOfWork.BeginTransactionAsync();

            // IList<Categoria> categoriasDescripcion = await _unitOfWork.CategoriaRepository.GetByCriteria(x => x.Descripcion == value);
            // IList<Producto> categoriasId = await _unitOfWork.ProductoRepository.GetByCriteria(x => x.IdNavigation.Descripcion == value);

            Categoria categoria = await _unitOfWork.CategoriaRepository.GetById(id);

            if (categoria != null)
            {
                categoria.Descripcion = value;
                await _unitOfWork.CategoriaRepository.Update(categoria);

                await _unitOfWork.CommitAsync();

                return categoria.Adapt<CategoriaDTO>();
            }
            else
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception("No se encontro la categoria");
            }
        }

        public async Task<IList<CategoriaDTO>> BuscarCategorias(string descripcion)
        {
            //Puedo Buscar por si contiene el nombre o podria buscar por is es igual al nombre
            // IList<Categoria> categorias = await _unitOfWork.CategoriaRepository.GetByCriteria(x => x.Descripcion.Contains(nombre));

            IList<Categoria> categorias = await _unitOfWork.CategoriaRepository.GetByCriteria(x => x.Descripcion == descripcion);

            IList<CategoriaDTO> categoriaDTO = categorias.Adapt<IList<CategoriaDTO>>();

            foreach (var item in categoriaDTO)
            {
                item.CantidadProductos = await _unitOfWork.CategoriaRepository.GetCantidadProductosByCategoria(item.Id);
            }

            return categoriaDTO;
        }
    }
}










// public ServicePrueba(MydbContext mydbContext)
// {
//     _dbContext = mydbContext;
// }





// public IList<CategoriaDTO> GetAllCategorias()
// {
//     // List<Categoria> categoria = _dbContext.Categoria.Include(x => x.Producto).ToList();

//     List<Categoria> categoria = _dbContext.Categoria.ToList();


//     List<CategoriaDTO> categoriaDTO = categoria.Adapt<List<CategoriaDTO>>().ToList();

//     foreach (var item in categoriaDTO)
//     {
//         int cantidadProductos = _dbContext.Producto.Where(x => x.Id == item.Id).Count();
//         item.CantidadProductos = cantidadProductos;
//     }

//     return categoriaDTO;



// }

// public CategoriaDTO GetCategoriaById(int id)
// {

//     Categoria categoria = _dbContext.Categoria.Find(id);
//     // CategoriaDTO categoria = _dbContext.Categoria.Where(x => x.Id == id).FirstOrDefault().Adapt<CategoriaDTO>();



//     if (categoria != null)
//     {
//         return categoria.Adapt<CategoriaDTO>();
//     }
//     else
//     {
//         throw new Exception("No se encontro la categoria");
//     }
// }

// public void PostCategoria(CategoriaDTO categoria)
// {
//     _dbContext.Categoria.Add(categoria.Adapt<Categoria>());
//     _dbContext.SaveChanges();
// }