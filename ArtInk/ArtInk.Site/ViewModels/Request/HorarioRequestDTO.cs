using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record HorarioRequestDTO
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
    }
}
