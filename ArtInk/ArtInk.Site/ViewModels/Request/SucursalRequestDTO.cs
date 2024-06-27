using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtInk.Site.ViewModels.Request
{
    public record SucursalRequestDTO
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        public string Descripcion { get; set; } = null!;

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es requerido")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener exactamente 8 dígitos.")]
        public int Telefono { get; set; }

        [DisplayName("Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com|yahoo\.com|biz)$",
        ErrorMessage = "Por favor ingrese un correo válido de Gmail, Hotmail, Yahoo o Biz.")]
        public string CorreoElectronico { get; set; } = null!;

        [DisplayName("Distrito")]
        [Required(ErrorMessage = "El distrito es requerido")]
        public short IdDistrito { get; set; }

        [DisplayName("Dirección Exacta")]
        [Required(ErrorMessage = "La dirección es requerida")]
        public string? DireccionExacta { get; set; }

        public bool Activo { get; set; }

        [NotMapped]
        public IEnumerable<ProvinciaResponseDTO> Provincias { get; set; } = null!;

        [NotMapped]
        [DisplayName("Provincia")]
        [Required(ErrorMessage = "La provincia es requerida")]
        public byte IdProvincia { get; set; }

        [DisplayName("Cantón")]
        [NotMapped]
        [Required(ErrorMessage = "El cantón es requerido")]
        public byte IdCanton { get; set; }
    }
}
