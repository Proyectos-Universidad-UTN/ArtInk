using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record TipoServicioResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Duración")]
        public TimeOnly Duracion { get; set; }

        public virtual ICollection<ServicioResponseDTO> Servicios { get; set; } = new List<ServicioResponseDTO>();
    }
}