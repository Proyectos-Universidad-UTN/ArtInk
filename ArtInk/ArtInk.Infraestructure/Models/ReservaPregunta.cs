using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class ReservaPregunta
{
    [Key]
    public int Id { get; set; }

    public int IdReserva { get; set; }

    [StringLength(250)]
    public string Pregunta { get; set; } = null!;

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [ForeignKey("IdReserva")]
    [InverseProperty("ReservaPregunta")]
    public virtual Reserva IdReservaNavigation { get; set; } = null!;
}
