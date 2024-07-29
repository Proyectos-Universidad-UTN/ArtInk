namespace ArtInk.Application.DTOs;

public record DetallePedidoDto
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

    public virtual ICollection<DetallePedidoProductoDto> DetallePedidoProductos { get; set; } = new List<DetallePedidoProductoDto>();

    public virtual PedidoDto Pedido { get; set; } = null!;

    public virtual ServicioDto Servicio { get; set; } = null!;
}