using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record TipoPagoResponseDto
{
    public byte Id { get; set; }

    [DisplayName("Descripción")]
    public string Descripcion { get; set; } = null!;

    public int Referencia { get; set; }

    public virtual ICollection<FacturaResponseDto> Facturas { get; set; } = new List<FacturaResponseDto>();
}