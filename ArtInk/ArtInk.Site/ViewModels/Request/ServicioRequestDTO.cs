using System.ComponentModel;
using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ArtInk.Site.ViewModels.Request
{
    public record ServicioRequestDTO
    {
        public byte Id { get; set; }

        [DisplayName("Servicio")]
        [Required(ErrorMessage = "El servicio es requerido")]
        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "La descripción es requerida")]
        [MaxLength(150)]
        public string Descripcion { get; set; } = null!;

        [DisplayName("Tipo Servicio")]
        public byte IdTipoServicio { get; set; }

        public decimal Tarifa
        {
            get => !string.IsNullOrEmpty(TarifaFormateada) ? decimal.Parse(TarifaFormateada.Replace(",", ""), CultureInfo.InvariantCulture) : 0;
            set
            {
                TarifaFormateada = value.ToString("#,##0.00");
            }
        }

        [NotMapped]
        [DisplayName("Tarifa ¢")]
        [Required(ErrorMessage = "La tarifa es requerida")]
        [RegularExpression(@"^(?!0+\.00)(?=.{1,9}(\.|$))\d{1,3}(,\d{3})*(\.\d+)?$", ErrorMessage = "Ingrese un valor válido y mayor a 0")]
        public string TarifaFormateada { get; set; } = null!;

        [DisplayName("Observación")]
        [MaxLength(150)]
        public string? Observacion { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<TipoServicioResponseDTO>? TipoServicios { get; set; }
    }
}