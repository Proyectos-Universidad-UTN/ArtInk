namespace ArtInk.Application.DTOs;

public record UsuarioSucursalDto
{
    public short Id { get; set; }

    public short IdUsuario { get; set; }

    public byte IdSucursal { get; set; }

    public virtual SucursalDto Sucursal { get; set; } = null!;

    public virtual UsuarioDto Usuario { get; set; } = null!;
}