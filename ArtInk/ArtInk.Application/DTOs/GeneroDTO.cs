namespace ArtInk.Application.DTOs;

public record GeneroDto
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
}