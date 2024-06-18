using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record DetalleFacturaProductoResponseDTO
    {
        public long Id { get; set; }

        [DisplayName("Detalle")]
        public long IdDetalleFactura { get; set; }

        [DisplayName("Producto")]
        public short IdProducto { get; set; }

        public decimal Cantidad { get; set; }

        public virtual DetalleFacturaResponseDTO DetalleFactura { get; set; } = null!;

        public virtual ProductoResponseDTO Producto{ get; set; } = null!;
    }
}