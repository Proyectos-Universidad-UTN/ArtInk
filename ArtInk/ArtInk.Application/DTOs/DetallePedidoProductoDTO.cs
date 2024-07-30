using System.ComponentModel;

namespace ArtInk.Application.DTOs;

public record DetallePedidoProductoDto
{
    public long Id { get; set; }

    [DisplayName("Detalle")]
    public long IdDetallePedido { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }

    public virtual DetallePedidoDto DetallePedido { get; set; } = null!;

    public virtual ProductoDto Producto { get; set; } = null!;
}