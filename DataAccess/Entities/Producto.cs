using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Producto
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public string Nombre { get; set; } = null!;

    public int? IdCategoria { get; set; }

    public virtual Categoria? IdCategoriaNavigation { get; set; }
}
