using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record TipoServicioRequestDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Duración")]
    public TimeOnly Duracion { get; set; }
}