namespace ArtInk.Site.ViewModels.Response
{
    public record FacturaResponseDTO
    {
        public short Id { get; set; }

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

        //public virtual ICollection<DetalleFacturaDTO> DetalleFacturas { get; set; } = new List<DetalleFacturaDTO>();

        public virtual ClienteResponseDTO Cliente { get; set; } = null!;

        public virtual ImpuestoResponseDTO Impuesto { get; set; } = null!;

        public virtual TipoPagoResponseDTO TipoPago { get; set; } = null!;

        public virtual UsuarioSucursalResponseDTO UsuarioSucursal { get; set; } = null!;
    }
}
