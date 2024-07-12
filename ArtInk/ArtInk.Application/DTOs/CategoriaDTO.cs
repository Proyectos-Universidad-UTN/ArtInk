using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record CategoriaDto : BaseEntity
{
    public byte Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<ProductoDto> Productos { get; set; } = new List<ProductoDto>();
}