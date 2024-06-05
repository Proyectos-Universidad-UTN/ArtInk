using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Horario
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public DateOnly Dia { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<SucursalHorario> SucursalHorarios { get; set; } = new List<SucursalHorario>();
}
