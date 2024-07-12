using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record UnidadMedidaRequestDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Símbolo")]
    public string Simbolo { get; set; } = null!;
}