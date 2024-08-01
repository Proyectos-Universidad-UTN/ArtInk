namespace ArtInk.Site.ViewModels.Response;

public class DetallePedidoResponseDto
{
    public long Id { get; set; }

    public long IdPedido { get; set; }

    public byte IdServicio { get; set; }

    public byte NumeroLinea { get; set; }

    public short Cantidad { get; set; }

    public decimal TarifaServicio { get; set; }

    public decimal MontoSubtotal { get; set; }

    public decimal MontoImpuesto { get; set; }

    public decimal MontoTotal { get; set; }

    public virtual ICollection<DetallePedidoProductoResponseDto> DetallePedidoProductos { get; set; } = new List<DetallePedidoProductoResponseDto>();

    public virtual PedidoResponseDto Pedido { get; set; } = null!;

    public virtual ServicioResponseDto Servicio { get; set; } = null!;
}