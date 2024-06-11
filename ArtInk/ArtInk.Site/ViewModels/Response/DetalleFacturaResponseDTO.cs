

using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record DetalleFacturaResponseDTO
    {
        public short Id { get; set; }

        [DisplayName("Factura")]
        public short IdFactura { get; set; }

        [DisplayName("Servicio")]
        public byte IdServicio { get; set; }


        [DisplayName("Línea")]
        public byte NumeroLinea { get; set; }

        public short Cantidad { get; set; }


        [DisplayName("Tarifa")]
        public decimal TarifaServicio { get; set; }


        [DisplayName("Subtotal")]
        public decimal MontoSubtotal { get; set; }


        [DisplayName("Impuesto")]
        public decimal MontoImpuesto { get; set; }


        [DisplayName("Total")]
        public decimal MontoTotal { get; set; }

        public virtual ICollection<DetalleFacturaProductoResponseDTO> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProductoResponseDTO>();

        public virtual FacturaResponseDTO Factura { get; set; } = null!;

        public virtual ServicioResponseDTO Servicio { get; set; } = null!;

    }
}
