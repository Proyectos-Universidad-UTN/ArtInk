using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record DetalleFacturaRequestDTO
    {
        public long Id { get; set; }

        [DisplayName("Factura")]
        public long IdFactura { get; set; }

        [DisplayName("Servicio")]
        public byte IdServicio { get; set; }

        [DisplayName("Número Línea")]
        public byte NumeroLinea { get; set; }

        public short Cantidad { get; set; }

        [DisplayName("Tarifa Servicio")]
        public decimal TarifaServicio { get; set; }

        [DisplayName("Subtotal")]
        public decimal MontoSubtotal { get; set; }

        [DisplayName("Impuesto")]
        public decimal MontoImpuesto { get; set; }

        [DisplayName("Total")]
        public decimal MontoTotal { get; set; }
    }
}
