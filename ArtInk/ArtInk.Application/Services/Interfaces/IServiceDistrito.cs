using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceDistrito
{
    Task<ICollection<DistritoDto>> ListAsync(byte idCanton);

    Task<DistritoDto> FindByIdAsync(byte id);
}