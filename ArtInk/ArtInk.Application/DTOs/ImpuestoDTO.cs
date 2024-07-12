namespace ArtInk.Application.DTOs;

public record ImpuestoDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public virtual ICollection<FacturaDto> Facturas { get; set; } = new List<FacturaDto>();
}