namespace ArtInk.Application.RequestDTOs;

public record RequestCategoriaDto
{
    public byte Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;
}
