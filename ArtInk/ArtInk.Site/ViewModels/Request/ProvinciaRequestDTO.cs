namespace ArtInk.Site.ViewModels.Request;

public record ProvinciaRequestDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;
}