using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record CantonRequestDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Provincia")]
    public byte IdProvincia { get; set; }
}