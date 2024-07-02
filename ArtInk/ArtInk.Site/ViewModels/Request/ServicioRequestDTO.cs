using System.ComponentModel;
using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request
{
    public record ServicioRequestDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        [DisplayName("Tipo Servicio")]
        public byte IdTipoServicio { get; set; }

        public decimal Tarifa { get; set; }

        [DisplayName("Observación")]
        public string? Observacion { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<TipoServicioResponseDTO> TipoServicios { get; set; } = null!;
    }
}