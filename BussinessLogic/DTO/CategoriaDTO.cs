using System;
using DataAccess.Entities;

namespace BussinessLogic.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        public string? Descripcion { get; set; }


        public virtual ICollection<ProductoDTO> Producto { get; set; } = new List<ProductoDTO>();

        //quiero que me devuelva la cantidad de productos que tiene la categoria
        public int CantidadProductos { get; set; }
    }
}

