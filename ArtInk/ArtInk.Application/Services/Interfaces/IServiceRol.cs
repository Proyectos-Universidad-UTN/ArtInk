using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceRol
{
    Task<ICollection<RolDto>> ListAsync();

    Task<RolDto> FindByIdAsync(byte id);
}