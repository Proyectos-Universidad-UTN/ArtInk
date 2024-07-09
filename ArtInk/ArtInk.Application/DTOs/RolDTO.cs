using ArtInk.Application.DTOs.Base;

namespace ArtInk.Application.DTOs;

public record RolDTO : BaseEntity
{
    public byte Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<UsuarioDTO> Usuarios { get; set; } = new List<UsuarioDTO>();
}