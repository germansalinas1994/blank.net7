using System;
using DataAccess.Entities;

namespace BussinessLogic.DTO
{
	public class CategoriaDTO
	{
        public int Id { get; set; }

        public string? Descripcion { get; set; }

        public virtual ICollection<ProductoDTO> Producto { get; set; } = new List<ProductoDTO>();
    }
}

