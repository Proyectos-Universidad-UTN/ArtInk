using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Feriado
{
    [Key]
    public byte Id { get; set; }

    public byte IdSucursal { get; set; }

    [StringLength(80)]
    public string Nombre { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [ForeignKey("IdSucursal")]
    [InverseProperty("Feriado")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
