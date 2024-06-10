using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record DetalleFacturaProductoDTO
    {
        public short Id { get; set; }


        [DisplayName("Detalle")]
        public short IdDetalleFactura { get; set; }


        [DisplayName("Producto")]
        public short IdProducto { get; set; }

        public decimal Cantidad { get; set; }

        public virtual DetalleFacturaResponseDTO DetalleFactura { get; set; } = null!;

        public virtual ProductoResponseDTO IdProductoNavigation { get; set; } = null!;
    }
}