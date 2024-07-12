namespace ArtInk.Application.DTOs;

public record TipoPagoDto
{
    public byte Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Referencia { get; set; }

    public virtual ICollection<FacturaDto> Facturas { get; set; } = new List<FacturaDto>();
}