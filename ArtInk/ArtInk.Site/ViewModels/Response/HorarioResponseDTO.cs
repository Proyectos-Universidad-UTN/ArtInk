using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record HorarioResponseDTO
    {
        public short Id { get; set; }

        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }

        [DisplayName("Día")]
        public DateOnly Dia { get; set; }

        [DisplayName("Hora Inicio")]
        public TimeOnly HoraInicio { get; set; }

        [DisplayName("Hora Final")]
        public TimeOnly HoraFin { get; set; }

        public virtual SucursalResponseDTO Sucursal { get; set; } = null!;

        public virtual ICollection<SucursalHorarioResponseDTO> SucursalHorarios { get; set; } = new List<SucursalHorarioResponseDTO>();
    }
}