using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs;

public record DetalleFacturaProductoDTO
{
    public long Id { get; set; }

    [DisplayName("Detalle")]
    public long IdDetalleFactura { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetalleFacturaDTO DetalleFactura { get; set; } = null!;

    public virtual ProductoDTO Producto { get; set; } = null!;
}