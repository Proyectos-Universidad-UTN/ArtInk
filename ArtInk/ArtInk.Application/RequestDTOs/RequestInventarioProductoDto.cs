namespace ArtInk.Application.RequestDTOs;

public record RequestInventarioProductoDto: RequestBaseDTO
{
    public long Id { get; set; }

    public short IdInventario { get; set; }

    public short IdProducto { get; set; }

    public decimal Disponible { get; set; }

    public decimal Minima { get; set; }

    public decimal Maxima { get; set; }
}