using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceCanton
{
    Task<ICollection<CantonDTO>> ListAsync(byte idProvincia);

    Task<CantonDTO> FindByIdAsync(byte id);
}