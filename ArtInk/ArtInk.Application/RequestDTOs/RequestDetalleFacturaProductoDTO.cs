namespace ArtInk.Application.RequestDTOs;

public record RequestDetalleFacturaProductoDTO
{
    public long Id { get; set; }

    public long IdDetalleFactura { get; set; }

    public short IdProducto { get; set; }

    public decimal Cantidad { get; set; }
}
