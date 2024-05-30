using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class SucursalHorario
{
    [Key]
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdHorario { get; set; }

    [ForeignKey("IdHorario")]
    [InverseProperty("SucursalHorario")]
    public virtual Horario IdHorarioNavigation { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("SucursalHorario")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    [InverseProperty("IdSucursalHorarioNavigation")]
    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();
}
