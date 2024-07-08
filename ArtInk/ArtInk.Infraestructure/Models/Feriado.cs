using System;
using System.Collections.Generic;
using ArtInk.Infraestructure.Enums;

namespace ArtInk.Infraestructure.Models;

public partial class Feriado
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public MesEnum Mes { get; set; }

    public byte Dia { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<SucursalFeriado> SucursalFeriados { get; set; } = new List<SucursalFeriado>();

}
