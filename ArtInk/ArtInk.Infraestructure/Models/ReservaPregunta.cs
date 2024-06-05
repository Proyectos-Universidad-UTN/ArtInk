using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class ReservaPregunta
{
    public int Id { get; set; }

    public int IdReserva { get; set; }

    public string Pregunta { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
