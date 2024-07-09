using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceUsuario
{
    Task<ICollection<UsuarioDTO>> ListAsync();

    Task<UsuarioDTO> FindByIdAsync(short id);
}
