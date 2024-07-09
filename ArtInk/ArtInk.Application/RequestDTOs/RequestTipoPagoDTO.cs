namespace ArtInk.Application.RequestDTOs;

public record RequestTipoPagoDTO
{
    public byte Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Referencia { get; set; }
}