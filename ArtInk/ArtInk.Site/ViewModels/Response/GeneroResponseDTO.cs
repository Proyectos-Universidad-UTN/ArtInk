namespace ArtInk.Site.ViewModels.Response;

public record GeneroResponseDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UsuarioResponseDto> Usuarios { get; set; } = new List<UsuarioResponseDto>();
}