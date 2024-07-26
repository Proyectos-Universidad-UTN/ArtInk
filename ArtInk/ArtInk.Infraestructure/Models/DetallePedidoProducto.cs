namespace ArtInk.Infraestructure.Models;

public partial class DetallePedidoProducto
{
    public long Id { get; set; }

    public long IdDetallePedido { get; set; }

    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetallePedido IdDetallePedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}