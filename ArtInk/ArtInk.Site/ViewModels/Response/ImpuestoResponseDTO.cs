namespace ArtInk.Site.ViewModels.Response;

public record ImpuestoResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public virtual ICollection<FacturaResponseDto> Facturas { get; set; } = new List<FacturaResponseDto>();
}