using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record DetalleFacturaProductoResponseDto
{
    public long Id { get; set; }

    [DisplayName("Detalle")]
    public long IdDetalleFactura { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetalleFacturaResponseDto DetalleFactura { get; set; } = null!;

    public virtual ProductoResponseDto Producto { get; set; } = null!;
}