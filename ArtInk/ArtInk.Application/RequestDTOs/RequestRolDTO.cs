namespace ArtInk.Application.RequestDTOs;

public record RequestRolDto
{
    public byte Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Activo { get; set; }
}