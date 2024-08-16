using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response;

public record FacturaResponseDto
{
    public long Id { get; set; }

    public short IdCliente { get; set; }

    [DisplayName("Nombre")]
    public string NombreCliente { get; set; } = null!;

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateOnly Fecha { get; set; }

    [DisplayName("Forma Pago")]
    public byte IdTipoPago { get; set; }

    public short Consecutivo { get; set; }

    [DisplayName("Impuesto")]
    public byte IdImpuesto { get; set; }

    [DisplayName("% IVA")]
    public decimal PorcentajeImpuesto { get; set; }

    [DisplayName("Subtotal")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal SubTotal { get; set; }

    [DisplayName("Impuesto")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal MontoImpuesto { get; set; }

    [DisplayName("Total")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal MontoTotal { get; set; }

    public byte IdSucursal { get; set; }

    public virtual ICollection<DetalleFacturaResponseDto> DetalleFacturas { get; set; } = new List<DetalleFacturaResponseDto>();

    public virtual ClienteResponseDto Cliente { get; set; } = null!;

    public virtual ImpuestoResponseDto Impuesto { get; set; } = null!;

    public virtual TipoPagoResponseDto TipoPago { get; set; } = null!;

    public virtual UsuarioSucursalResponseDto UsuarioSucursal { get; set; } = null!;
    
    public SucursalResponseDto Sucursal { get; set; } = null!;
}