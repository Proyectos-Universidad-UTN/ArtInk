namespace ArtInk.Application.RequestDTOs;

public record RequestProvinciaDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;
}
