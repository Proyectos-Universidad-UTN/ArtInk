using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record CantonResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Provincia")]
        public byte IdProvincia { get; set; }

        public virtual ICollection<DistritoResponseDTO> Distritos { get; set; } = new List<DistritoResponseDTO>();

        public virtual ProvinciaResponseDTO Provincia { get; set; } = null!;
    }
}