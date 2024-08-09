using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces.Authorization;

public interface IServiceUserAuthorization
{
    Task<UsuarioDto> GetLoggedUser();
}