using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class DetalleFactura
{
    public long Id { get; set; }

    public long IdFactura { get; set; }

    public byte IdServicio { get; set; }

    public byte NumeroLinea { get; set; }

    public short Cantidad { get; set; }

    public decimal TarifaServicio { get; set; }

    public decimal MontoSubtotal { get; set; }

    public decimal MontoImpuesto { get; set; }

    public decimal MontoTotal { get; set; }

    public virtual ICollection<DetalleFacturaProducto> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProducto>();

    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}
