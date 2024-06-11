namespace ArtInk.Site.ViewModels.Response
{
    public record FeriadoResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public DateOnly? Fecha { get; set; }

        public bool Activo { get; set; }

        public virtual ICollection<SucursalFeriadoResponseDTO> SucursalFeriados { get; set; } = new List<SucursalFeriadoResponseDTO>();
    }
}