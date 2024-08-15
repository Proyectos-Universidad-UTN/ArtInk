using ArtInk.Application.DTOs.Enums;

namespace ArtInk.Application.DTOs.Authentication;

public record CurrentUser
{
    public short IdUsuario { get; init; }

    public string? CorreoElectronico { get; init; }

    public Rol? Role { get; init; }
}