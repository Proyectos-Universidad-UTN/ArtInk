using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Request
{
    public record SucursalRequestDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        [DisplayName("Teléfono")]
        public int Telefono { get; set; }

        [DisplayName("Correo Electrónico")]
        public string CorreoElectronico { get; set; } = null!;

        [DisplayName("Distrito")]
        public short IdDistrito { get; set; }

        [DisplayName("Dirección Exacta")]
        public string? DireccionExacta { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<DistritoResponseDTO> Distritos { get; set; } = null!;
    }
}
