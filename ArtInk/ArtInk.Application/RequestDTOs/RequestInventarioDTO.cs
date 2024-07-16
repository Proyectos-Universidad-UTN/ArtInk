namespace ArtInk.Application.RequestDTOs;

public record RequestInventarioDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdSucursal { get; set; }

    public bool Activo { get; set; }
}
