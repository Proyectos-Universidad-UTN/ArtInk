using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestCategoriaDTO
    {
        public byte Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;
    }
}
