using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs
{
    public record CategoriaDTO : BaseEntity
    {
        public byte Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public virtual ICollection<ProductoDTO> Productos { get; set; } = new List<ProductoDTO>();
    }
}