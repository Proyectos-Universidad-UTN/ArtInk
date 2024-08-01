namespace ArtInk.Application.DTOs;

public record DetalleFacturaDto
{
    public long Id { get; set; }

    public long IdFactura { get; set; }

    public byte IdServicio { get; set; }

    public byte NumeroLinea { get; set; }

    public short Cantidad { get; set; }

    public decimal TarifaServicio { get; set; }

    public decimal MontoSubtotal { get; set; }

    public decimal MontoImpuesto { get; set; }

    public decimal MontoTotal { get; set; }

    public virtual ICollection<DetalleFacturaProductoDto> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProductoDto>();

    public virtual FacturaDto Factura { get; set; } = null!;

    public virtual ServicioDto? Servicio { get; set; } = null!;
}