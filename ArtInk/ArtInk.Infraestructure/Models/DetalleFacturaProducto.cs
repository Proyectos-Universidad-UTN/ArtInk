using System;
using System.Collections.Generic;

namespace ArtInk.Infraestructure.Models;

public partial class DetalleFacturaProducto
{
    public short Id { get; set; }

    public short IdDetalleFactura { get; set; }

    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetalleFactura IdDetalleFacturaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
