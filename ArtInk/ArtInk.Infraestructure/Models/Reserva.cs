using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Reserva
{
    [Key]
    public int Id { get; set; }

    public DateOnly Fecha { get; set; }

    public TimeOnly Hora { get; set; }

    public short IdSucursalHorario { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Estado { get; set; } = null!;

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [ForeignKey("IdSucursalHorario")]
    [InverseProperty("Reserva")]
    public virtual SucursalHorario IdSucursalHorarioNavigation { get; set; } = null!;

    [InverseProperty("IdReservaNavigation")]
    public virtual ICollection<ReservaPregunta> ReservaPregunta { get; set; } = new List<ReservaPregunta>();

    [InverseProperty("IdReservaNavigation")]
    public virtual ICollection<ReservaServicio> ReservaServicio { get; set; } = new List<ReservaServicio>();
}
