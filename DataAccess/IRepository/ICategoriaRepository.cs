using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.IRepository
{

    // Esta interfaz es para que la implementen los repositorios de cada entidad, generico para que no se repita codigo
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {

        //hago una interfaz de la clase producto para que el repositorio de categoria tenga sus propios metodos especificos

        //Task<IEnumerable<Categoria>> GetByNombre(string nombre);
        //Task<IEnumerable<Categoria>> GetByDescripcion(string descripcion);

        //Task<long> GetCount();
        //Task<long> GetProductosByCategoria(int idCategoria);
        
        // //el guid es para que el repositorio de cada entidad tenga un identificador unico

        // Guid GetGuid();

    } 
}