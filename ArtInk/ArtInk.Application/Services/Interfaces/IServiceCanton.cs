using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceCanton
{
    Task<ICollection<CantonDto>> ListAsync(byte idProvincia);

    Task<CantonDto> FindByIdAsync(byte id);
}