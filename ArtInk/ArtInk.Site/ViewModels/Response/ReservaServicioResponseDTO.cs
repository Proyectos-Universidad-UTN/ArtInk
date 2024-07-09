using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record ReservaServicioResponseDTO
    {
        public int Id { get; set; }

        [DisplayName("Reserva")]
        public int IdReserva { get; set; }

        [DisplayName("Servicio")]
        public byte IdServicio { get; set; }

        public virtual ReservaResponseDTO Reserva { get; set; } = null!;

        public virtual ServicioResponseDTO Servicio { get; set; } = null!;
    }
}