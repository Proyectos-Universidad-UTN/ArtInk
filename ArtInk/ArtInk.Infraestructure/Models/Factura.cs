using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class Factura
{
    [Key]
    public short Id { get; set; }

    public short IdCliente { get; set; }

    [StringLength(160)]
    public string NombreCliente { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public byte IdTipoPago { get; set; }

    public short Consecutivo { get; set; }

    public short IdUsuarioSucursal { get; set; }

    public byte IdImpuesto { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal PorcentajeImpuesto { get; set; }

    [Column(TypeName = "money")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal MontoImpuesto { get; set; }

    [Column(TypeName = "money")]
    public decimal MontoTotal { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaCreacion { get; set; }

    [StringLength(70)]
    public string UsuarioCreacion { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? FechaModificacion { get; set; }

    [StringLength(70)]
    public string? UsuarioModificacion { get; set; }

    [InverseProperty("IdFacturaNavigation")]
    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    [ForeignKey("IdCliente")]
    [InverseProperty("Factura")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    [ForeignKey("IdImpuesto")]
    [InverseProperty("Factura")]
    public virtual Impuesto IdImpuestoNavigation { get; set; } = null!;

    [ForeignKey("IdTipoPago")]
    [InverseProperty("Factura")]
    public virtual TipoPago IdTipoPagoNavigation { get; set; } = null!;

    [ForeignKey("IdUsuarioSucursal")]
    [InverseProperty("Factura")]
    public virtual UsuarioSucursal IdUsuarioSucursalNavigation { get; set; } = null!;
}
