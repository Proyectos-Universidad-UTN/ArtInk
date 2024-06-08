using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Feriado
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<SucursalFeriado> SucursalFeriados { get; set; } = new List<SucursalFeriado>();

}
