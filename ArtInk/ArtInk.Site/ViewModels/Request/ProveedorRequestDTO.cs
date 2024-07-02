using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record ProveedorRequestDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Cédula Jurídica")]
        public string CedulaJuridica { get; set; } = null!;

        [DisplayName("Razón Social")]
        public string RasonSocial { get; set; } = null!;

        [DisplayName("Teléfono")]
        public int Telefono { get; set; }

        [DisplayName("Correo Electrónico")]
        public string CorreoElectronico { get; set; } = null!;

        [DisplayName("Distrito")]
        public short IdDistrito { get; set; }

        [DisplayName("Dirección Exacta")]
        public string? DireccionExacta { get; set; }

        public bool Activo { get; set; }
    }
}
