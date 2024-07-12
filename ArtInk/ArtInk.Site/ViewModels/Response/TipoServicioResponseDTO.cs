using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record TipoServicioResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Duración")]
    public TimeOnly Duracion { get; set; }

    public virtual ICollection<ServicioResponseDto> Servicios { get; set; } = new List<ServicioResponseDto>();
}