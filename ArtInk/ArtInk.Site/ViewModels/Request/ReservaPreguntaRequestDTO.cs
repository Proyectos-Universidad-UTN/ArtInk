using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request;

public record ReservaPreguntaRequestDto
    {
        public int Id { get; set; }

        [DisplayName("Reserva")]
        public int IdReserva { get; set; }

        public string Pregunta { get; set; } = null!;

        public bool Activo { get; set; }
        
        public string Respuesta { get; set; } = null!;
    }