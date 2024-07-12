using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceUsuario
{
    Task<ICollection<UsuarioDto>> ListAsync();

    Task<UsuarioDto> FindByIdAsync(short id);
}