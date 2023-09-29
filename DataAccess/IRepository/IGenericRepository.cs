using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.IRepository
{

    // Esta interfaz es para que la implementen los repositorios de cada entidad, generico para que no se repita codigo
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<T>> GetByCriteria(Func<T, bool> predicate);
        // Task<bool> Exist(int id);
        // Task<bool> Exist(Func<T, bool> predicate);
        // Task<bool> RemoveAll(IEnumerable<T> entities);
        // Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);

        
        // //el guid es para que el repositorio de cada entidad tenga un identificador unico

        // Guid GetGuid();


    } 
}