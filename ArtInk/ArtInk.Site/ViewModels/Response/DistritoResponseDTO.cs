using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record DistritoResponseDTO
    {
        public short Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Cantón")]
        public byte IdCanton { get; set; }

        public virtual ICollection<ClienteResponseDTO> Clientes { get; set; } = new List<ClienteResponseDTO>();

        public virtual CantonResponseDTO Canton { get; set; } = null!;

        public virtual ICollection<ProveedorResponseDTO> Proveedores { get; set; } = new List<ProveedorResponseDTO>();

        public virtual ICollection<SucursalResponseDTO> Sucursales { get; set; } = new List<SucursalResponseDTO>();

        public virtual ICollection<UsuarioResponseDTO> Usuarios { get; set; } = new List<UsuarioResponseDTO>();

    }
}
