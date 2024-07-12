namespace ArtInk.Site.ViewModels.Request;

public record GeneroRequestDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;
}