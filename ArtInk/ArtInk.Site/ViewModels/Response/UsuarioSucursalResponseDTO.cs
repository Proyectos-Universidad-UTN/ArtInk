using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record UsuarioSucursalResponseDto
{
    public short Id { get; set; }

    [DisplayName("Usuario")]
    public short IdUsuario { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    public virtual ICollection<FacturaResponseDto> Facturas { get; set; } = new List<FacturaResponseDto>();

    public virtual ICollection<ReservaResponseDto> Reservas { get; set; } = new List<ReservaResponseDto>();

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;

    public virtual UsuarioResponseDto Usuario { get; set; } = null!;
}