using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestSucursalFeriadoDTO
    {
        public short Id { get; set; }

        public byte IdFeriado { get; set; }

        public byte IdSucursal { get; set; }
    }
}
