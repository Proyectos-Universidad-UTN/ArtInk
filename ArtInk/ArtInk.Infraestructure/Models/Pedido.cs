namespace ArtInk.Infraestructure.Models
{
    public partial class Pedido: BaseModel
    {
        public long Id { get; set; }

        public short IdCliente { get; set; }

        public string NombreCliente { get; set; } = null!;

        public DateOnly Fecha { get; set; }

        public byte IdTipoPago { get; set; }

        public short Consecutivo { get; set; }

        public byte IdImpuesto { get; set; }

        public decimal PorcentajeImpuesto { get; set; }

        public int IdReserva { get; set; }

        public decimal SubTotal { get; set; }

        public decimal MontoImpuesto { get; set; }

        public decimal MontoTotal { get; set; }

        public char Estado { get; set; }

        public byte IdSucursal { get; set; }

        public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

        public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

        public virtual Cliente IdClienteNavigation { get; set; } = null!;

        public virtual Impuesto IdImpuestoNavigation { get; set; } = null!;

        public virtual TipoPago IdTipoPagoNavigation { get; set; } = null!;

        public virtual Reserva IdReservaNavigation { get; set; } = null!;

        public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
    }
}
