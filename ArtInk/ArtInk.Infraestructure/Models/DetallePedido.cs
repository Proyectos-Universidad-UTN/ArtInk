﻿namespace ArtInk.Infraestructure.Models;

public partial class DetallePedido
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

    public virtual ICollection<DetallePedidoProducto> DetallePedidoProductos { get; set; } = new List<DetallePedidoProducto>();

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;
}