using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record CantonResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Provincia")]
    public byte IdProvincia { get; set; }

    public virtual ICollection<DistritoResponseDto> Distritos { get; set; } = new List<DistritoResponseDto>();

    public virtual ProvinciaResponseDto Provincia { get; set; } = null!;
}