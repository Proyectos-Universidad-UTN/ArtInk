namespace ArtInk.Application.RequestDTOs;

public class RequestInventarioProductoDto
{
    public long Id { get; set; }

    public short IdInventario { get; set; }

    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    public byte Minima { get; set; }

    public byte Maxima { get; set; }
}