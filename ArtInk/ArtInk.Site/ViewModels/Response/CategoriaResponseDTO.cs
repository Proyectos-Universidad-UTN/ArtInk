namespace ArtInk.Site.ViewModels.Response
{
    public record CategoriaResponseDTO
    {
        public byte Id { get; set; }

        public string Codigo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

    }
}