using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestServicioDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public byte IdTipoServicio { get; set; }

        public decimal Tarifa { get; set; }

        public string? Observacion { get; set; }

        public bool Activo { get; set; }
    }
}
