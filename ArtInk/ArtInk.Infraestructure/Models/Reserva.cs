using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class Reserva
{
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public short IdSucursalHorario { get; set; }

    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual SucursalHorario IdSucursalHorarioNavigation { get; set; } = null!;

    public virtual ICollection<ReservaPreguntum> ReservaPregunta { get; set; } = new List<ReservaPreguntum>();

    public virtual ICollection<ReservaServicio> ReservaServicios { get; set; } = new List<ReservaServicio>();
}
