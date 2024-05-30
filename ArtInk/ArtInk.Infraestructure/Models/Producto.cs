using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Producto
{
    [Key]
    public short Id { get; set; }

    [StringLength(70)]
    public string Nombre { get; set; } = null!;

    [StringLength(150)]
    public string Descripcion { get; set; } = null!;

    [StringLength(50)]
    public string Marca { get; set; } = null!;

    public byte IdCategoria { get; set; }

    [Column(TypeName = "money")]
    public decimal Costo { get; set; }

    [Column("SKU")]
    [StringLength(50)]
    public string Sku { get; set; } = null!;

    public short Cantidad { get; set; }

    public byte IdUnidadMedida { get; set; }

    public bool Activo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<DetalleFacturaProducto> DetalleFacturaProducto { get; set; } = new List<DetalleFacturaProducto>();

    [ForeignKey("IdCategoria")]
    [InverseProperty("Producto")]
    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    [ForeignKey("IdUnidadMedida")]
    [InverseProperty("Producto")]
    public virtual UnidadMedida IdUnidadMedidaNavigation { get; set; } = null!;

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<Inventario> Inventario { get; set; } = new List<Inventario>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<ServicioProducto> ServicioProducto { get; set; } = new List<ServicioProducto>();
}
