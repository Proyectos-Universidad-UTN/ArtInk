using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record UsuarioRequestDTO
    {
        public short Id { get; set; }

        [DisplayName("Cédula")]
        public string Cedula { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        [DisplayName("Teléfono")]
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

        [DisplayName("Fotografía")]
        public string? UrlFoto { get; set; }

        [DisplayName("Rol")]
        public byte IdRol { get; set; }
    }
}
