using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.DTOs
{
    public record SucursalFeriadoDTO
    {
        public short Id { get; set; }

        public byte IdFeriado { get; set; }

        public byte IdSucursal { get; set; }

        public virtual FeriadoDTO Feriado { get; set; } = null!;

        public virtual SucursalDTO Sucursal { get; set; } = null!;

    }
}
