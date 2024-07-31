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

        public short IdCliente { get; set; }

        [DisplayName("Cliente")]
        public string NombreCliente { get; set; } = null!;

        [DisplayName("Fecha")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateOnly Fecha { get; set; }

        [DisplayName("Tipo de pago")]
        public byte IdTipoPago { get; set; }

        [DisplayName("Número")]
        public short Consecutivo { get; set; }

        public short IdUsuarioSucursal { get; set; }

        public byte IdImpuesto { get; set; }

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
        [Required(ErrorMessage = "El % impuesto es obligatorio")]
        [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
        public string PorcentajeImpuestoFormateado { get; set; } = null!;

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
        [Required(ErrorMessage = "El subtotal es obligatorio")]
        [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
        public string SubTotalFormateado { get; set; } = null!;

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
        [Required(ErrorMessage = "El monto impuesto es obligatorio")]
        [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
        public string MontoImpuestoFormateado { get; set; } = null!;

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
        [Required(ErrorMessage = "El monto total es obligatorio")]
        [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
        public string MontoTotalFormateado { get; set; } = null!;

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

        private void CalcularTotales()
        {
            SubTotal = DetallePedidos.Sum(m => m.MontoSubtotal);
            MontoImpuesto = SubTotal * (PorcentajeImpuesto / 100);
            MontoTotal = SubTotal + MontoImpuesto;
        }

        private void OrdenarNumeroLineasDetalle()
        {
            var conteoTotal = DetallePedidos.Count;
            DetallePedidos.ForEach(m => { var valorActual = conteoTotal - 1; m.NumeroLinea = (byte)(conteoTotal - valorActual); conteoTotal--; });
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
                    TarifaServicio = item.Servicio.Tarifa
                };
                AgregarDetallePedido(detallePedido);
            }
        }
    }
}

