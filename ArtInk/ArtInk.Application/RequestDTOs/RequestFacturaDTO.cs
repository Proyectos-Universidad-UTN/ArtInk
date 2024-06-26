﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.RequestDTOs
{
    public record RequestFacturaDTO
    {
        public long Id { get; set; }

        public short IdCliente { get; set; }

        public string NombreCliente { get; set; } = null!;

        public DateOnly Fecha { get; set; }

        public byte IdTipoPago { get; set; }

        public short Consecutivo { get; set; }

        public short IdUsuarioSucursal { get; set; }

        public byte IdImpuesto { get; set; }

        public decimal PorcentajeImpuesto { get; set; }

        public decimal SubTotal { get; set; }

        public decimal MontoImpuesto { get; set; }

        public decimal MontoTotal { get; set; }
    }
}
