namespace ArtInk.Application.DTOs;

public record ImpuestoDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Porcentaje { get; set; }

    public virtual ICollection<FacturaDTO> Facturas { get; set; } = new List<FacturaDTO>();
}