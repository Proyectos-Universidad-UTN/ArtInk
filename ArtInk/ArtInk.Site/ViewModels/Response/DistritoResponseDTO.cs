using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.ViewModels.Response
{
    public record DistritoResponseDTO
    {
        public short Id { get; set; }

        public string Nombre { get; set; } = null!;

        public byte IdCanton { get; set; }

        //public virtual ICollection<ClienteDTO> Clientes { get; set; } = new List<ClienteDTO>();

        //public virtual CantonDTO Canton { get; set; } = null!;

        //public virtual ICollection<ProveedorDTO> Proveedores { get; set; } = new List<ProveedorDTO>();

        //public virtual ICollection<SucursalDTO> Sucursales { get; set; } = new List<SucursalDTO>();

        //public virtual ICollection<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
    }
}


