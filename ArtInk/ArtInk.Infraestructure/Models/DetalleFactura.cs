using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Models;

public partial class DetalleFactura
{
    [Key]
    public short Id { get; set; }

    public short IdFactura { get; set; }

    public byte IdServicio { get; set; }

    public byte NumeroLinea { get; set; }

    public short Cantidad { get; set; }

    [Column(TypeName = "money")]
    public decimal TarifaServicio { get; set; }

    [Column(TypeName = "money")]
    public decimal MontoSubtotal { get; set; }

    [Column(TypeName = "money")]
    public decimal MontoImpuesto { get; set; }

    [Column(TypeName = "money")]
    public decimal MontoTotal { get; set; }

    [InverseProperty("IdDetalleFacturaNavigation")]
    public virtual ICollection<DetalleFacturaProducto> DetalleFacturaProducto { get; set; } = new List<DetalleFacturaProducto>();

    [ForeignKey("IdFactura")]
    [InverseProperty("DetalleFactura")]
    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    [ForeignKey("IdServicio")]
    [InverseProperty("DetalleFactura")]
    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
