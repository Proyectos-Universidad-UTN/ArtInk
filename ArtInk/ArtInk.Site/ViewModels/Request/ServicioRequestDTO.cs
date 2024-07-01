using ArtInk.Site.ViewModels.Response;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        [DisplayName("Tipo de servicio")]
        public byte IdTipoServicio { get; set; }

        [Required(ErrorMessage = "La tarifa es requerida")]
        public decimal Tarifa { get; set; }

        [DisplayName("Observación")]
        public string? Observacion { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<TipoServicioResponseDTO> TipoServicios { get; set; } = null;
    }
}
