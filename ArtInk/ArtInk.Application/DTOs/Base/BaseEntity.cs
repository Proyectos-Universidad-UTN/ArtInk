using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs.Base
{
    public record  BaseEntity
    {
        // record no cambia
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; } = null!;
        public DateTime? FechaModificacion { get; set; }
        public string? UsuarioModificacion { get; set; }
    }
}
