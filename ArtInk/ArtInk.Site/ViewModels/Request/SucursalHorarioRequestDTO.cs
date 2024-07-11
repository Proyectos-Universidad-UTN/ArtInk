using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtInk.Site.ViewModels.Request
{
    public record SucursalHorarioRequestDTO
    {
        public short Id { get; set; }

        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }

        [DisplayName("Horario")]
        public short IdHorario { get; set; }

        [NotMapped]
        public HorarioResponseDTO Horario { get; set; } = null!;
    }
}
