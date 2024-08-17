﻿namespace ArtInk.Application.RequestDTOs;

public record RequestPedidoDto: RequestBaseDto
{
    public long Id { get; set; }

    public short IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public byte IdTipoPago { get; set; }

    public short Consecutivo { get; set; }

    public byte IdImpuesto { get; set; }

    public int IdReserva { get; set; }

    public decimal PorcentajeImpuesto { get; set; }

    public decimal SubTotal { get; set; }

    public decimal MontoImpuesto { get; set; }

    public decimal MontoTotal { get; set; }

    public char Estado { get; set; }

    public byte IdSucursal { get; set; }

    public IEnumerable<RequestDetallePedidoDto> DetallePedidos { get; set; } = null!;
}