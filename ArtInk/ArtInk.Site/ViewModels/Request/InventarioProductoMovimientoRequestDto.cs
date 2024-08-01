using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;
using ArtInk.Site.ViewModels.Common;

namespace ArtInk.Site.ViewModels.Request;

public record InventarioProductoMovimientoRequestDto
{
    public long Id { get; set; }

    public long IdInventarioProducto { get; set; }

    public TipoMovimientoInventario TipoMovimiento { get; set; }

    [JsonRequired]
    public decimal Cantidad
    {
        get => !string.IsNullOrEmpty(CantidadFormateada) ? Decimal.Parse(CantidadFormateada.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
        set
        {
            CantidadFormateada = value.ToString("#,##0.00");
        }
    }

    [NotMapped]
    [DisplayName("Cantidad")]
    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
    public string CantidadFormateada { get; set; } = null!;

    public InventarioProductoMovimientoRequestDto()
    {
    }

    public InventarioProductoMovimientoRequestDto(TipoMovimientoInventario tipoMovimiento) => TipoMovimiento = tipoMovimiento;
}