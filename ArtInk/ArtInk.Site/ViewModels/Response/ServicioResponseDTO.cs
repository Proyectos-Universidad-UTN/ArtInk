namespace ArtInk.Site.ViewModels.Response
{
    public record ServicioReponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public byte IdTipoServicio { get; set; }

        public decimal Tarifa { get; set; }

        public string? Observacion { get; set; }

        public bool Activo { get; set; }

        //public virtual ICollection<DetalleFacturaDTO> DetalleFacturas { get; set; } = new List<DetalleFacturaDTO>();

        public virtual TipoServicioResponseDTO TipoServicio { get; set; } = null!;

        //public virtual ICollection<ReservaServicioDTO> ReservaServicios { get; set; } = new List<ReservaServicioDTO>();
    }
}
