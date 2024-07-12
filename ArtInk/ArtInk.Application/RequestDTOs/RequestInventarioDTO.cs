namespace ArtInk.Application.RequestDTOs;

public record RequestInventarioDto
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    public byte Minima { get; set; }

    public byte Maxima { get; set; }
}
