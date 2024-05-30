using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Inventario
{
    [Key]
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    public byte Minima { get; set; }

    public byte Maxima { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [ForeignKey("IdProducto")]
    [InverseProperty("Inventario")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;

    [ForeignKey("IdSucursal")]
    [InverseProperty("Inventario")]
    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
