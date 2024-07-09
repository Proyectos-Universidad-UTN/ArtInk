namespace ArtInk.Application.RequestDTOs;

public record RequestCategoriaDTO
{
    public byte Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;
}
