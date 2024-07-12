namespace ArtInk.Application.DTOs;

public record UnidadMedidaDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Simbolo { get; set; } = null!;

    public virtual ICollection<ProductoDto> Productos { get; set; } = new List<ProductoDto>();
}