using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record FacturaRequestDTO
    {
        public long Id { get; set; }

        [DisplayName("Cliente")]
        public short IdCliente { get; set; }

        [DisplayName("Nombre")]
        public string NombreCliente { get; set; } = null!;

        public DateOnly Fecha { get; set; }

        [DisplayName("Tipo Pago")]
        public byte IdTipoPago { get; set; }

        public short Consecutivo { get; set; }

        [DisplayName("Usuario")]
        public short IdUsuarioSucursal { get; set; }

        [DisplayName("Impuesto")]
        public byte IdImpuesto { get; set; }

        [DisplayName("% Impuesto")]
        public decimal PorcentajeImpuesto { get; set; }

        [DisplayName("SubTotal")]
        public decimal SubTotal { get; set; }

        [DisplayName("Monto Impuesto")]
        public decimal MontoImpuesto { get; set; }

        [DisplayName("Total")]
        public decimal MontoTotal { get; set; }
    }
}
