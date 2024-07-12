using System.ComponentModel;

namespace ArtInk.Application.DTOs;

public record DetalleFacturaProductoDto
{
    public long Id { get; set; }

    [DisplayName("Detalle")]
    public long IdDetalleFactura { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetalleFacturaDto DetalleFactura { get; set; } = null!;

    public virtual ProductoDto Producto { get; set; } = null!;
}