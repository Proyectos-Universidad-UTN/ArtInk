using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Horario
{
    [Key]
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public DateOnly Dia { get; set; }

    public TimeOnly HoraInicio { get; set; }

    public TimeOnly HoraFin { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [ForeignKey("IdSucursal")]
    [InverseProperty("Horario")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    [InverseProperty("IdHorarioNavigation")]
    public virtual ICollection<SucursalHorario> SucursalHorario { get; set; } = new List<SucursalHorario>();
}
