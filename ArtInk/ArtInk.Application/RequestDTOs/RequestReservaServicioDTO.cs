using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestReservaServicioDTO
    {
        public int Id { get; set; }

        public int IdReserva { get; set; }

        public byte IdServicio { get; set; }
    }
}
