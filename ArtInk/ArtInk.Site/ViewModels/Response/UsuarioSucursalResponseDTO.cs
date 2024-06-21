using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record UsuarioSucursalResponseDTO
    {
        public short Id { get; set; }

        [DisplayName("Usuario")]
        public short IdUsuario { get; set; }

        [DisplayName("Sucursal")]
        public byte IdSucursal { get; set; }

        public virtual ICollection<FacturaResponseDTO> Facturas { get; set; } = new List<FacturaResponseDTO>();

        public virtual ICollection<ReservaResponseDTO> Reservas { get; set; } = new List<ReservaResponseDTO>();

        public virtual SucursalResponseDTO Sucursal { get; set; } = null!;

        public virtual UsuarioResponseDTO Usuario { get; set; } = null!;
    }
}
