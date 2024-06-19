using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestDistritoDTO
    {
        public short Id { get; set; }

        public string Nombre { get; set; } = null!;

        public byte IdCanton { get; set; }
    }
}
