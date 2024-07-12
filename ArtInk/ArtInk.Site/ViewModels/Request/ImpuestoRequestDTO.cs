namespace ArtInk.Site.ViewModels.Request;

public record ImpuestoRequestDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Porcentaje { get; set; }
}