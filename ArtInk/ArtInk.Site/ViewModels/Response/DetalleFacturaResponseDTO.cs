﻿

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response
{
    public record DetalleFacturaResponseDTO
    {
        public long Id { get; set; }

        [DisplayName("Factura")]
        public long IdFactura { get; set; }

        [DisplayName("Servicio")]
        public byte IdServicio { get; set; }

        [DisplayName("Línea")]
        public byte NumeroLinea { get; set; }

        public short Cantidad { get; set; }

        [DisplayName("Tarifa")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TarifaServicio { get; set; }

        [DisplayName("Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal MontoSubtotal { get; set; }

        [DisplayName("Impuesto")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal MontoImpuesto { get; set; }

        [DisplayName("Total Línea")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal MontoTotal { get; set; }

        public virtual ICollection<DetalleFacturaProductoResponseDTO> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProductoResponseDTO>();

        public virtual FacturaResponseDTO Factura { get; set; } = null!;

        public virtual ServicioResponseDTO Servicio { get; set; } = null!;

    }
}
