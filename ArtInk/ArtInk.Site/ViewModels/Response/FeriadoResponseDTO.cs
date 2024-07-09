using System.ComponentModel;
using ArtInk.Site.ViewModels.Common;

namespace ArtInk.Site.ViewModels.Response
{
    public record FeriadoResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public bool Activo { get; set; }

        public MesEnum Mes { get; set; }

        [DisplayName("Día")]
        public byte Dia { get; set; }

        public virtual ICollection<SucursalFeriadoResponseDTO> SucursalFeriados { get; set; } = new List<SucursalFeriadoResponseDTO>();
    }
}