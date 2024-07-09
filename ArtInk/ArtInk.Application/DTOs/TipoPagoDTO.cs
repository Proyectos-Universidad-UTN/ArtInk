namespace ArtInk.Application.DTOs;

public record TipoPagoDTO
{
    public byte Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Referencia { get; set; }

    public virtual ICollection<FacturaDTO> Facturas { get; set; } = new List<FacturaDTO>();
}