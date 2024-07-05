using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record TipoPagoRequestDTO
    {
        public byte Id { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        public int Referencia { get; set; }
    }
}
