using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record UsuarioResponseDTO
    {
        public short Id { get; set; }

        [DisplayName("Cédula")]
        public string Cedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        [DisplayName("Télefono")]
        public int Telefono { get; set; }

        [DisplayName("Correo Electrónico")]
        public string CorreoElectronico { get; set; } = null!;

        [DisplayName("Distrito")]
        public short IdDistrito { get; set; }

        [DisplayName("Dirección Exacta")]
        public string? DireccionExacta { get; set; }

        [DisplayName("Fecha Nacimiento")]
        public DateOnly FechaNacimiento { get; set; }

        [DisplayName("Contraseña")]
        public string Contrasenna { get; set; } = null!;

        [DisplayName("Género")]
        public byte IdGenero { get; set; }
        public bool Activo { get; set; }

        public string? UrlFoto { get; set; }

        [DisplayName("Rol")]
        public byte IdRol { get; set; }

        public virtual DistritoResponseDTO Distrito { get; set; } = null!;

        public virtual GeneroResponseDTO Genero { get; set; } = null!;

        public virtual RolResponseDTO Rol { get; set; } = null!;
        public virtual ICollection<UsuarioSucursalResponseDTO> UsuarioSucursal { get; set; } = new List<UsuarioSucursalResponseDTO>();

    }
}
