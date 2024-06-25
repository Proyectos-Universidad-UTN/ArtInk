using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Request
{
    public record ServicioRequestDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public byte IdTipoServicio { get; set; }

        public decimal Tarifa { get; set; }

        public string? Observacion { get; set; }

        public bool Activo { get; set; }

        public IEnumerable<TipoServicioResponseDTO> TipoServicios { get; set; } = null;
    }
}
