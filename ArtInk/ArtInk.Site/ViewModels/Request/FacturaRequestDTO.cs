using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

namespace ArtInk.Site.ViewModels.Request;

public record FacturaRequestDto
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

    public IEnumerable<ClienteResponseDto>? Clientes { get; set; } = null!;

    public IEnumerable<TipoPagoResponseDto>? TipoPagos { get; set; } = null!;

    public IEnumerable<ImpuestoResponseDto>? Impuestos { get; set; } = null!;

    public List<DetalleFacturaRequestDto> DetalleFacturas { get; set; } = new List<DetalleFacturaRequestDto>();

    public void AgregarDetalleFactura(DetalleFacturaRequestDto detalleFactura)
    {
        DetalleFacturas.Add(detalleFactura);
        CalcularTotales();
    }

    public void EliminarDetalleImpuesto(byte numeroLinea)
    {
        var detalleEliminar = DetalleFacturas.Single(m => m.NumeroLinea == numeroLinea);
        DetalleFacturas.Remove(detalleEliminar);
        CalcularTotales();
        OrdenarNumeroLineasDetalle();
    }

    private void CalcularTotales()
    {
        SubTotal = DetalleFacturas.Sum(m => m.MontoSubtotal);
        MontoImpuesto = SubTotal * (PorcentajeImpuesto / 100);
        MontoTotal = SubTotal + MontoImpuesto;
    }

    private void OrdenarNumeroLineasDetalle()
    {
        var conteoTotal = DetalleFacturas.Count;
        DetalleFacturas.ForEach(m => { var valorActual = conteoTotal - 1; m.NumeroLinea = (byte)(conteoTotal - valorActual); conteoTotal--; });
    }

    public byte SiguienteNumeroLinea() => DetalleFacturas.Count == 0 ? (byte)1 : (byte)(DetalleFacturas.Max(m => m.NumeroLinea) + 1);
}