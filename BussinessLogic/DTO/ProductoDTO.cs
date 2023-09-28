using System;
using DataAccess.Entities;

namespace BussinessLogic.DTO
{
	public class ProductoDTO
	{
        public int Id { get; set; }

        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        // public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
    }
}

