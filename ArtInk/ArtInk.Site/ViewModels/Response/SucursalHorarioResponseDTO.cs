using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record SucursalHorarioResponseDTO
    {
        public short Id { get; set; }


        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }


        [DisplayName("Horario")]
        public short IdHorario { get; set; }

        public virtual HorarioResponseDTO Horario { get; set; } = null!;

        public virtual SucursalResponseDTO Sucursal { get; set; } = null!;

        public virtual ICollection<ReservaResponseDTO> Reservas { get; set; } = new List<ReservaResponseDTO>();
    }
}