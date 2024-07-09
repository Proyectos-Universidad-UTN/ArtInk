namespace ArtInk.Application.DTOs;

public record UnidadMedidaDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Simbolo { get; set; } = null!;

    public virtual ICollection<ProductoDTO> Productos { get; set; } = new List<ProductoDTO>();
}