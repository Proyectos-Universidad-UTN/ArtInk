namespace ArtInk.Application.DTOs;

public record GeneroDTO
{
    public byte Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
}