using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record CategoriaResponseDto
{
    public byte Id { get; set; }

    [DisplayName("Código")]
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;
}