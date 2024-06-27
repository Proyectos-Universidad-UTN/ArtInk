using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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

        [NotMapped]
        public IEnumerable<ProvinciaResponseDTO> Provincias { get; set; } = null!;

        [NotMapped]
        public byte IdProvincia { get; set; }

        [NotMapped]
        public byte IdCanton { get; set; }
    }
}
