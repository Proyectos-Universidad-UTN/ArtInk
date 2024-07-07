namespace ArtInk.Application.RequestDTOs;

public record RequestUnidadMedidaDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Simbolo { get; set; } = null!;
}