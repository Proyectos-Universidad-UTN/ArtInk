using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Categoria
{
    public byte Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
