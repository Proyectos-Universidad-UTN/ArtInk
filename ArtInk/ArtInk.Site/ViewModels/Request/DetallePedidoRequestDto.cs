using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;
using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request;

public record DetallePedidoRequestDto
{
    public long Id { get; set; }

    [DisplayName("Pedido")]
    public long IdPedido { get; set; }

    [DisplayName("Servicio")]
    public byte IdServicio { get; set; }

    [DisplayName("Número Línea")]
    public byte NumeroLinea { get; set; }

    [JsonRequired]
    public short Cantidad 
    { 
        get => !string.IsNullOrEmpty(CantidadFormateada) ? short.Parse(CantidadFormateada.Replace(",", ""), CultureInfo.InvariantCulture) : (short)0; 
        set => CantidadFormateada = value.ToString("#,##0"); 
    }

    [NotMapped]
    [Required(ErrorMessage = "Cantidad requerid")]
    [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
    public string CantidadFormateada { get; set; }

    [DisplayName("Tarifa Servicio")]
    public decimal TarifaServicio { get; set; }

    [JsonRequired]
    public decimal MontoSubtotal 
    { 
        get => !string.IsNullOrEmpty(MontoSubtotalFormateado) ? decimal.Parse(MontoSubtotalFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;  
        set => MontoSubtotalFormateado = value.ToString("#,##0.00"); 
    }

    [NotMapped]
    [DisplayName("Subtotal")]
    public string MontoSubtotalFormateado { get; set; }

    [JsonRequired]
    public decimal MontoImpuesto 
    { 
        get => !string.IsNullOrEmpty(MontoImpuestoFormateado) ? decimal.Parse(MontoImpuestoFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;  
        set => MontoImpuestoFormateado = value.ToString("#,##0.00"); 
    }

    [NotMapped]
    [DisplayName("Impuesto")]
    public string MontoImpuestoFormateado { get; set; }

    [JsonRequired]
    public decimal MontoTotal 
    { 
        get => !string.IsNullOrEmpty(MontoTotalFormateado) ? decimal.Parse(MontoTotalFormateado.Replace(",", ""), CultureInfo.InvariantCulture) : 0;  
        set => MontoTotalFormateado = value.ToString("#,##0.00"); 
    }

    [NotMapped]
    [DisplayName("Total")]
    public string MontoTotalFormateado { get; set; }

    public ServicioResponseDto? Servicio { get; set; }
}
