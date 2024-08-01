using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;
using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request;

public class InventarioProductoRequestDto
{
    public long Id { get; set; }

    public short IdInventario { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    [JsonRequired]
    public decimal Disponible { get; set; }

    [JsonRequired]
    public decimal Minima
    {
        get => !string.IsNullOrEmpty(MinimaFormateada) ? Decimal.Parse(MinimaFormateada.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
        set
        {
            MinimaFormateada = value.ToString("#,##0.00");
        }
    }

    [NotMapped]
    [DisplayName("Cantidad mínima")]
    [Required(ErrorMessage = "La cantidad mínima es obligatoria")]
    [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
    public string MinimaFormateada { get; set; } = null!;

    [JsonRequired]
    public decimal Maxima
    {
        get => !string.IsNullOrEmpty(MaximaFormateada) ? Decimal.Parse(MaximaFormateada.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
        set
        {
            MaximaFormateada = value.ToString("#,##0.00");
        }
    }

    [NotMapped]
    [DisplayName("Cantidad máxima")]
    [Required(ErrorMessage = "La cantidad máxima es obligatoria")]
    [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
    public string MaximaFormateada { get; set; } = null!;

    public IEnumerable<ProductoResponseDto> Productos { get; set; } = new List<ProductoResponseDto>();
}