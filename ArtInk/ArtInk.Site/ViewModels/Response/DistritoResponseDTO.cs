using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record DistritoResponseDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Cantón")]
    public byte IdCanton { get; set; }

    public virtual ICollection<ClienteResponseDto> Clientes { get; set; } = new List<ClienteResponseDto>();

    public virtual CantonResponseDto Canton { get; set; } = null!;

    public virtual ICollection<ProveedorResponseDto> Proveedores { get; set; } = new List<ProveedorResponseDto>();

    public virtual ICollection<SucursalResponseDto> Sucursales { get; set; } = new List<SucursalResponseDto>();

    public virtual ICollection<UsuarioResponseDto> Usuarios { get; set; } = new List<UsuarioResponseDto>();

    public virtual ICollection<CantonResponseDto> Cantones { get; set; } = new List<CantonResponseDto>();
}