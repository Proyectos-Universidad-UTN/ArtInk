namespace ArtInk.Application.DTOs;

public record DistritoDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    public byte IdCanton { get; set; }

    public virtual ICollection<ClienteDto> Clientes { get; set; } = new List<ClienteDto>();

    public virtual CantonDto Canton { get; set; } = null!;

    public virtual ICollection<ProveedorDto> Proveedores { get; set; } = new List<ProveedorDto>();

    public virtual ICollection<SucursalDto> Sucursales { get; set; } = new List<SucursalDto>();

    public virtual ICollection<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
}