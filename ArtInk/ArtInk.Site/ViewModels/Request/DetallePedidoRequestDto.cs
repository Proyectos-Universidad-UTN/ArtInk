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

    [DisplayName("Subtotal")]
    public decimal MontoSubtotal { get; set; }

    [DisplayName("Impuesto")]
    public decimal MontoImpuesto { get; set; }

    [DisplayName("Total")]
    public decimal MontoTotal { get; set; }

    public ServicioResponseDto? Servicio { get; set; }
}
