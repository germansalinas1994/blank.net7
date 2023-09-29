using System;
using System.Security.Cryptography.X509Certificates;
using BussinessLogic.DTO;
using DataAccess.IRepository;
using DataAccess.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic.Services
{
    public class ServicePrueba
    {

        // private static ServicePrueba _instance;
        // private static readonly object _lock = new object();

        // private readonly IUnitOfWork _unitOfWork;

        // // El constructor privado evita que se cree una instancia desde fuera de la clase.
        // private ServicePrueba(IUnitOfWork unitOfWork)
        // {
        //     _unitOfWork = unitOfWork;
        // }

        // // Método estático para obtener la única instancia del servicio.
        // public static ServicePrueba GetInstance(IUnitOfWork unitOfWork)
        // {
        //     if (_instance == null)
        //     {
        //         lock (_lock)
        //         {
        //             if (_instance == null)
        //             {
        //                 _instance = new ServicePrueba(unitOfWork);
        //             }
        //         }
        //     }
        //     return _instance;
        // }




        private readonly IUnitOfWork _unitOfWork;

        public ServicePrueba(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<CategoriaDTO>> GetAllCategorias()
        {
            IEnumerable<Categoria> categorias = await _unitOfWork.CategoriaRepository.GetAll();

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
//         int cantidadProductos = _dbContext.Producto.Where(x => x.IdCategoria == item.Id).Count();
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