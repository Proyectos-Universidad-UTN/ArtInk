using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestHorarioDTO
    {
        public short Id { get; set; }

        public byte IdSucursal { get; set; }

        public DateOnly Dia { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }
    }
}
