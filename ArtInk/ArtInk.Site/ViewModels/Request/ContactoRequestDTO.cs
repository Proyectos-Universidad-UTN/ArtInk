using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record ContactoRequestDTO
    {
        public short Id { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; } = null!;

        [DisplayName("Apellidos")]
        public string Apellidos { get; set; } = null!;

        [DisplayName("Teléfono")]
        public int Telefono { get; set; }

        [DisplayName("Correo Electrónico")]
        public string CorreoElectronico { get; set; } = null!;

        [DisplayName("Proveedor")]
        public byte IdProveedor { get; set; }

        public bool Activo { get; set; }
    }
}
