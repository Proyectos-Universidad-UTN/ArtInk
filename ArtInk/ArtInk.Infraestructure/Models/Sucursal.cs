using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Sucursal
{
    [Key]
    public byte Id { get; set; }

    [StringLength(80)]
    public string Nombre { get; set; } = null!;

    [StringLength(150)]
    public string Descripcion { get; set; } = null!;

    public int Telefono { get; set; }

    [StringLength(50)]
    public string CorreoElectronico { get; set; } = null!;

    public short IdDistrito { get; set; }

    [StringLength(250)]
    public string? DireccionExacta { get; set; }

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Feriado> Feriado { get; set; } = new List<Feriado>();

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Horario> Horario { get; set; } = new List<Horario>();

    [ForeignKey("IdDistrito")]
    [InverseProperty("Sucursal")]
    public virtual Distrito IdDistritoNavigation { get; set; } = null!;

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<SucursalHorario> SucursalHorario { get; set; } = new List<SucursalHorario>();

    [InverseProperty("IdSucursalNavigation")]
    public virtual ICollection<UsuarioSucursal> UsuarioSucursal { get; set; } = new List<UsuarioSucursal>();
}
