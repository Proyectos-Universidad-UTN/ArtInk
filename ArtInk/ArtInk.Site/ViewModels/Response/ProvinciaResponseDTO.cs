namespace ArtInk.Site.ViewModels.Response
{
    public record ProvinciaResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<CantonResponseDTO> Cantons { get; set; } = new List<CantonResponseDTO>();
    }
}