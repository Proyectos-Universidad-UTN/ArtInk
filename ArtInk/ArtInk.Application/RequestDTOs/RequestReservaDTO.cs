using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestReservaDTO
    {
        public int Id { get; set; }

        public DateOnly Fecha { get; set; }

        public TimeOnly Hora { get; set; }

        public short IdSucursalHorario { get; set; }

        public string Estado { get; set; } = null!;

        public bool Activo { get; set; }
    }
}
