using ArtInk.Site.ViewModels.Response;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ArtInk.Site.ViewModels.Request;

public record FacturaRequestDto
{
    public long Id { get; set; }

    [DisplayName("Cliente")]
    [Range(1, 99999, ErrorMessage = "Seleccione un cliente")]
    public short IdCliente { get; set; }

    [DisplayName("Nombre")]
    public string NombreCliente { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
    public DateOnly Fecha { get; set; }

    [DisplayName("Tipo de pago")]
    [Range(1, 99999, ErrorMessage = "Debe seleccionar el tipo de pago")]
    public byte IdTipoPago { get; set; }

    [Range(1, 999999, ErrorMessage = "Debe indicar el pedido")]
    public long? IdPedido { get; set; }

    [DisplayName("Número")]
    public short Consecutivo { get; set; }

    [DisplayName("Impuesto")]
    public byte IdImpuesto { get; set; }

    [DisplayName("Servicio")]
    public byte IdServicio { get; set; }

    public char Accion { get; set; } = 'A';

    public byte NumeroLineaEliminar { get; set; }

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

    public decimal MontoTotal
    {
        get => !string.IsNullOrEmpty(MontoTotalFormateado) ? Decimal.Parse(MontoTotalFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
        set
        {
            MontoTotalFormateado = value.ToString("#,##0.00");
        }
    }

    [JsonIgnore]
    [DisplayName("Total ¢")]
    public string? MontoTotalFormateado { get; set; }

    public byte IdSucursal { get; set; }

    [JsonIgnore]
    public IEnumerable<ServicioResponseDto>? Servicios { get; set; } = null!;

    [JsonIgnore]
    public IEnumerable<ClienteResponseDto>? Clientes { get; set; } = null!;

    [JsonIgnore]
    public IEnumerable<TipoPagoResponseDto>? TipoPagos { get; set; } = null!;

    [JsonIgnore]
    public IEnumerable<ImpuestoResponseDto>? Impuestos { get; set; } = null!;

    public List<DetalleFacturaRequestDto> DetalleFacturas { get; set; } = new List<DetalleFacturaRequestDto>();

    public IEnumerable<SucursalResponseDto>? Sucursales { get; set; } = new List<SucursalResponseDto>();

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

    public void CalcularTotales()
    {
        SubTotal = DetalleFacturas.Sum(m => m.MontoSubtotal);
        MontoImpuesto = SubTotal * (PorcentajeImpuesto / 100);
        MontoTotal = SubTotal + MontoImpuesto;
    }

    private void OrdenarNumeroLineasDetalle()
    {
        var conteoTotal = DetalleFacturas.Count;
        DetalleFacturas.ForEach(m => { conteoTotal--; m.NumeroLinea = (byte)(DetalleFacturas.Count - conteoTotal); });
    }

    public byte SiguienteNumeroLinea() => DetalleFacturas.Count == 0 ? (byte)1 : (byte)(DetalleFacturas.Max(m => m.NumeroLinea) + 1);

    public void PrecargarDetalle(ICollection<DetallePedidoResponseDto> detallePedido)
    {
        foreach (var item in detallePedido)
        {
            var detalleFactura = new DetalleFacturaRequestDto()
            {
                IdServicio = item.IdServicio,
                NumeroLinea = SiguienteNumeroLinea(),
                Servicio = item.Servicio,
                TarifaServicio = item.Servicio.Tarifa,
                Cantidad = item.Cantidad,
                MontoSubtotal = item.MontoSubtotal,
                MontoImpuesto = item.MontoImpuesto,
                MontoTotal = item.MontoTotal,
            };
            AgregarDetalleFactura(detalleFactura);
        }
    }
}