using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestReservaPreguntaDTO
    {
        public int Id { get; set; }

        public int IdReserva { get; set; }

        public string Pregunta { get; set; } = null!;

        public bool Activo { get; set; }

        public string Respuesta { get; set; } = null!;
        }
}
