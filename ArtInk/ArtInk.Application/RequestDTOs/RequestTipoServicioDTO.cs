using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestTipoServicioDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public TimeOnly Duracion { get; set; }
    }
}
