using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record FeriadoRequestDTO
    {
        public byte Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = null!;

        public DateOnly? Fecha { get; set; }

        public bool Activo { get; set; }
    }
}
