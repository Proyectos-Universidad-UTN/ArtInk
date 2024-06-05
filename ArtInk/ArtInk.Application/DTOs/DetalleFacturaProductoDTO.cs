using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record DetalleFacturaProductoDTO
{
    public short Id { get; set; }

    public short IdDetalleFactura { get; set; }

    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetalleFacturaDTO DetalleFactura { get; set; } = null!;

    public virtual ProductoDTO IdProductoNavigation { get; set; } = null!;
}