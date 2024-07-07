namespace ArtInk.Application.RequestDTOs;

public record RequestCantonDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdProvincia { get; set; }
}