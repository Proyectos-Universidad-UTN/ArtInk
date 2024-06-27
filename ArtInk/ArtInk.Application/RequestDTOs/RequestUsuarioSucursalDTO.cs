using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestUsuarioSucursalDTO
    {
        public short Id { get; set; }

        public short IdUsuario { get; set; }

        public byte IdSucursal { get; set; }
    }
}
