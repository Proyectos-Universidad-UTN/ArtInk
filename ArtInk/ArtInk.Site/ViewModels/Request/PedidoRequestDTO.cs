using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ArtInk.Site.ViewModels.Request
{
    public record PedidoRequestDto
    {
        public long Id { get; set; }

        [DisplayName("Cliente")]
        [Range(1, 99999, ErrorMessage = "Seleccione un cliente")]
        public short IdCliente { get; set; }

        [DisplayName("Nombre del cliente")]
        public string NombreCliente { get; set; } = null!;

        [DisplayName("Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateOnly Fecha { get; set; }

        [DisplayName("Tipo de pago")]
        [Range(1, 99999, ErrorMessage = "Debe seleccionar el tipo de pago")]
        public byte IdTipoPago { get; set; }

        [DisplayName("Número")]
        public short Consecutivo { get; set; }

        [DisplayName("Impuesto")]
        [Range(1, 99999, ErrorMessage = "Debe seleccionar el impuesto a aplicar")]
        public byte IdImpuesto { get; set; }

        [Range(1, 999999, ErrorMessage = "Debe indicar la reserva")]
        public int IdReserva { get; set; }

        [DisplayName("Servicio")]
        public byte IdServicio { get; set; }

        public char Accion { get; set; } = 'A';

        public byte NumeroLineaEliminar { get; set; }

        [JsonRequired]
        public decimal PorcentajeImpuesto
        {
            get => !string.IsNullOrEmpty(PorcentajeImpuestoFormateado) ? Decimal.Parse(PorcentajeImpuestoFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
            set
            {
                PorcentajeImpuestoFormateado = value.ToString("#,##0.00");
            }
        }

        [NotMapped]
        [DisplayName("% Impuesto")]
        public string? PorcentajeImpuestoFormateado { get; set; }

        [JsonRequired]
        public decimal SubTotal
        {
            get => !string.IsNullOrEmpty(SubTotalFormateado) ? Decimal.Parse(SubTotalFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
            set
            {
                SubTotalFormateado = value.ToString("#,##0.00");
            }
        }

        [NotMapped]
        [DisplayName("SubTotal ¢")]
        public string? SubTotalFormateado { get; set; }

        [JsonRequired]
        public decimal MontoImpuesto
        {
            get => !string.IsNullOrEmpty(MontoImpuestoFormateado) ? Decimal.Parse(MontoImpuestoFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
            set
            {
                MontoImpuestoFormateado = value.ToString("#,##0.00");
            }
        }

        [NotMapped]
        [DisplayName("Impuesto ¢")]
        public string? MontoImpuestoFormateado { get; set; }

        [JsonRequired]
        public decimal MontoTotal
        {
            get => !string.IsNullOrEmpty(MontoTotalFormateado) ? Decimal.Parse(MontoTotalFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
            set
            {
                MontoTotalFormateado = value.ToString("#,##0.00");
            }
        }

        [NotMapped]
        [DisplayName("Total ¢")]
        public string? MontoTotalFormateado { get; set; }

        public char Estado { get; set; }

        public byte IdSucursal { get; set; }

        public IEnumerable<ServicioResponseDto>? Servicios { get; set; } = null!;

        public List<DetallePedidoRequestDto> DetallePedidos { get; set; } = new List<DetallePedidoRequestDto>();

        public IEnumerable<ClienteResponseDto>? Clientes { get; set; } = null!;

        public IEnumerable<ImpuestoResponseDto>? Impuestos { get; set; } = null!;

        public IEnumerable<TipoPagoResponseDto>? TipoPagos { get; set; } = null!;

        public void AgregarDetallePedido(DetallePedidoRequestDto detallePedido)
        {
            DetallePedidos.Add(detallePedido);
            CalcularTotales();
        }

        public void EliminarDetalleImpuesto(byte numeroLinea)
        {
            var detalleEliminar = DetallePedidos.Single(m => m.NumeroLinea == numeroLinea);
            DetallePedidos.Remove(detalleEliminar);
            CalcularTotales();
            OrdenarNumeroLineasDetalle();
        }

        public void CalcularTotales()
        {
            SubTotal = DetallePedidos.Sum(m => m.MontoSubtotal);
            MontoImpuesto = SubTotal * (PorcentajeImpuesto / 100);
            MontoTotal = SubTotal + MontoImpuesto;
        }

        private void OrdenarNumeroLineasDetalle()
        {
            var conteoTotal = DetallePedidos.Count;
            DetallePedidos.ForEach(m => { conteoTotal--; m.NumeroLinea = (byte)(DetallePedidos.Count - conteoTotal); });
        }

        public byte SiguienteNumeroLinea() => DetallePedidos.Count == 0 ? (byte)1 : (byte)(DetallePedidos.Max(m => m.NumeroLinea) + 1);

        public void PrecargarDetalle(ICollection<ReservaServicioResponseDto> servicios)
        {
            foreach (var item in servicios)
            {
                var detallePedido = new DetallePedidoRequestDto()
                {
                    IdServicio = item.IdServicio,
                    NumeroLinea = SiguienteNumeroLinea(),
                    Servicio = item.Servicio,
                    TarifaServicio = item.Servicio.Tarifa,
                    Cantidad = 0,
                    MontoSubtotal = 0,
                    MontoImpuesto = 0,
                    MontoTotal = 0,
                };
                AgregarDetallePedido(detallePedido);
            }
        }
    }
}