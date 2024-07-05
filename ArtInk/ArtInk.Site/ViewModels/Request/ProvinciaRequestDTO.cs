namespace ArtInk.Site.ViewModels.Request
{
    public record ProvinciaRequestDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
