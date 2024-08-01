using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response;

public class PedidoResponseDto
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

    public decimal PorcentajeImpuesto { get; set; }

    [DisplayName("Subtotal")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal SubTotal { get; set; }

    [DisplayName("Monto impuesto")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal MontoImpuesto { get; set; }

    [DisplayName("Monto total")]
    [DisplayFormat(DataFormatString = "{0:C2}")]
    public decimal MontoTotal { get; set; }

    public virtual ICollection<DetallePedidoResponseDto> DetallePedidos { get; set; } = new List<DetallePedidoResponseDto>();

    public virtual ClienteResponseDto Cliente { get; set; } = null!;

    public virtual ImpuestoResponseDto Impuesto { get; set; } = null!;

    public virtual TipoPagoResponseDto TipoPago { get; set; } = null!;

    public virtual UsuarioSucursalResponseDto UsuarioSucursal { get; set; } = null!;
}