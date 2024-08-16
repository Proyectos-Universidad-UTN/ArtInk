using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record UsuarioSucursalResponseDto
{
    public short Id { get; set; }

    [DisplayName("Usuario")]
    public short IdUsuario { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;

    public virtual UsuarioResponseDto Usuario { get; set; } = null!;
}