using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record CategoriaRequestDTO
    {
        public byte Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; } = null!;

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = null!;
    }
}
