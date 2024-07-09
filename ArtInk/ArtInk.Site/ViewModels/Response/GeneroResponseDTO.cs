namespace ArtInk.Site.ViewModels.Response
{
    public record GeneroResponseDTO
    {
        public byte Id { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<UsuarioResponseDTO> Usuarios { get; set; } = new List<UsuarioResponseDTO>();
    }
}