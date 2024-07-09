using ArtInk.Site.ViewModels.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Request
{
    public record SucursalRequestDTO: Direcciones
    {
        public byte Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(150)]
        public string Descripcion { get; set; } = null!;

        public int Telefono { 
            get{
                return !string.IsNullOrEmpty(TelefonoFormateado) ? int.Parse(TelefonoFormateado.Replace("-", "")) : 0;
            } 
            set{
                TelefonoFormateado = value.ToString();
            } 
        }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es requerido")]
        [RegularExpression(@"^\d{4}\-\d{4}$", ErrorMessage = "Por favor complete el teléfono")]
        [MaxLength(9)]
        public string TelefonoFormateado { get; set; } = string.Empty;

        [DisplayName("Correo Electrónico")]
        [Required(ErrorMessage = "El correo electrónico es requerido")]
        [EmailAddress(ErrorMessage = "Por favor ingrese una dirección de correo válido")]
        public string CorreoElectronico { get; set; } = null!;

        [DisplayName("Dirección Exacta")]
        [MaxLength(250)]
        public string? DireccionExacta { get; set; }

        public bool Activo { get; set; }
    }
}
