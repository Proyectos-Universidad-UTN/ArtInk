using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceRol
{
    Task<ICollection<RolDTO>> ListAsync();

    Task<RolDTO> FindByIdAsync(byte id);
}