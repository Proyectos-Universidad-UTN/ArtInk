namespace ArtInk.Site.ViewModels.Request
{
    public record GeneroRequestDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
