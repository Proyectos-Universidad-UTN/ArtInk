namespace ArtInk.Application.DTOs;

public record UsuarioSucursalDto
{
    public short Id { get; set; }

    public short IdUsuario { get; set; }

    public byte IdSucursal { get; set; }

    public virtual ICollection<FacturaDto> Facturas { get; set; } = new List<FacturaDto>();

    public virtual ICollection<ReservaDto> Reservas { get; set; } = new List<ReservaDto>();

    public virtual SucursalDto Sucursal { get; set; } = null!;

    public virtual UsuarioDto Usuario { get; set; } = null!;
}