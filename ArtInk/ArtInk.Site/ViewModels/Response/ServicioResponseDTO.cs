using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response
{
    public record ServicioReponseDTO
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

        //public virtual ICollection<DetalleFacturaDTO> DetalleFacturas { get; set; } = new List<DetalleFacturaDTO>();

        public virtual TipoServicioResponseDTO TipoServicio { get; set; } = null!;

        //public virtual ICollection<ReservaServicioDTO> ReservaServicios { get; set; } = new List<ReservaServicioDTO>();
    }
}
