namespace ArtInk.Application.RequestDTOs;

public record RequestUsuarioSucursalDTO
{
    public short Id { get; set; }

    public short IdUsuario { get; set; }

    public byte IdSucursal { get; set; }
}