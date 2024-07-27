using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public class DetallePedidoProductoResponseDto
{
    public long Id { get; set; }

    [DisplayName("Detalle")]
    public long IdDetallePedido { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetallePedidoResponseDto DetallePedido { get; set; } = null!;

    public virtual ProductoResponseDto Producto { get; set; } = null!;
}