using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record DetalleFacturaProductoRequestDTO
    {
        public long Id { get; set; }

        [DisplayName("Detalle Factura")]
        public long IdDetalleFactura { get; set; }

        [DisplayName("Producto")]
        public short IdProducto { get; set; }

        public decimal Cantidad { get; set; }
    }
}
