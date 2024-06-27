using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestTipoPagoDTO
    {
        public byte Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public int Referencia { get; set; }
    }
}
