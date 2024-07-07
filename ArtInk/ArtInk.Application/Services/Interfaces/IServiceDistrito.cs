using ArtInk.Application.DTOs;
namespace ArtInk.Application.Services.Interfaces;

public interface IServiceDistrito
{
    Task<ICollection<DistritoDTO>> ListAsync(byte idCanton);

    Task<DistritoDTO> FindByIdAsync(byte id);
}