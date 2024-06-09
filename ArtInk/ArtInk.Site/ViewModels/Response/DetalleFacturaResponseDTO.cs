}namespace ArtInk.Site.ViewModels.Response
{
    public record DetalleFacturaResponseDTO
    {
        public short Id { get; set; }

        public short IdFactura { get; set; }

        public byte IdServicio { get; set; }

        public byte NumeroLinea { get; set; }

        public short Cantidad { get; set; }

        public decimal TarifaServicio { get; set; }

        public decimal MontoSubtotal { get; set; }

        public decimal MontoImpuesto { get; set; }

        public decimal MontoTotal { get; set; }

        //public virtual ICollection<DetalleFacturaProductoDTO> DetalleFacturaProductos { get; set; } = new List<DetalleFacturaProductoDTO>();

        public virtual FacturaResponseDTO Factura { get; set; } = null!;

        //public virtual  ServicioResponseDTO { get; set; } = null!;
    }
}
