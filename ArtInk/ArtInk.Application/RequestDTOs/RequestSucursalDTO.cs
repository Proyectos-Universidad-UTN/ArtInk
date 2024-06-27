﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestSucursalDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public int Telefono { get; set; }

        public string CorreoElectronico { get; set; } = null!;

        public short IdDistrito { get; set; }

        public string? DireccionExacta { get; set; }

        public bool Activo { get; set; }
    }
}
