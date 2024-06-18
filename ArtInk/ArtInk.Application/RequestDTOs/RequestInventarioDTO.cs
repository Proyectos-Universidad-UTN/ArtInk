using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestInventarioDTO
    {
        public short Id { get; set; }

        public byte IdSucursal { get; set; }

        public short IdProducto { get; set; }

        public byte Disponible { get; set; }

        public byte Minima { get; set; }

        public byte Maxima { get; set; }
    }
}
