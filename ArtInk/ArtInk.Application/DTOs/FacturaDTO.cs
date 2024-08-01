using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record FacturaDto: BaseEntity
{
    public long Id { get; set; }

    public short IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public long? IdPedido { get; set; }

    public DateOnly Fecha { get; set; }

    public byte IdTipoPago { get; set; }

    public short Consecutivo { get; set; }

    public short IdUsuarioSucursal { get; set; }

    public byte IdImpuesto { get; set; }

    public decimal PorcentajeImpuesto { get; set; }

    public decimal SubTotal { get; set; }

    public decimal MontoImpuesto { get; set; }

    public decimal MontoTotal { get; set; }

    public virtual ICollection<DetalleFacturaDto> DetalleFacturas { get; set; } = new List<DetalleFacturaDto>();

    public virtual ClienteDto Cliente { get; set; } = null!;

    public virtual ImpuestoDto Impuesto { get; set; } = null!;

    public virtual TipoPagoDto TipoPago { get; set; } = null!;

    public virtual UsuarioSucursalDto UsuarioSucursal { get; set; } = null!;

    public virtual PedidoDto? Pedido { get; set; }
}