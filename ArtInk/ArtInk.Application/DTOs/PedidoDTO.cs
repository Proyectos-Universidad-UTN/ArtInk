using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record PedidoDto : BaseEntity
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

    public virtual ICollection<DetallePedidoDto> DetallePedidos { get; set; } = new List<DetallePedidoDto>();

    public virtual ClienteDto Cliente { get; set; } = null!;

    public virtual ImpuestoDto Impuesto { get; set; } = null!;

    public virtual TipoPagoDto TipoPago { get; set; } = null!;

    public virtual ReservaDto Reserva { get; set; } = null!;

    public virtual SucursalDto Sucursal { get; set; } = null!;
}