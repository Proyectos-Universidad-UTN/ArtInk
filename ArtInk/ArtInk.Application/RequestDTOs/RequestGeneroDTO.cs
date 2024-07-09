namespace ArtInk.Application.RequestDTOs;

public record RequestGeneroDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;
}