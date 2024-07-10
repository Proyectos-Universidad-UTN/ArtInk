using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArtInk.Site.ViewModels.Response
{
    public record ServicioResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        [DisplayName("Descripción")]
        public string Descripcion { get; set; } = null!;

        [DisplayName("Tipo Servicio")]
        public byte IdTipoServicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Tarifa { get; set; }

        [DisplayName("Observación")]
        public string? Observacion { get; set; }

        public bool Activo { get; set; }

        public virtual TipoServicioResponseDTO TipoServicio { get; set; } = null!;
    }
}
