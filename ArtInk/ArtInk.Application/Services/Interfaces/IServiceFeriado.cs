using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceFeriado
{
    Task<ICollection<FeriadoDTO>> ListAsync();

    Task<FeriadoDTO> FindByIdAsync(byte id);

    Task<FeriadoDTO> CreateFeriadoAsync(RequestFeriadoDTO feriadoDTO);

    Task<FeriadoDTO> UpdateFeriadoAsync(byte id, RequestFeriadoDTO feriadoDTO);

    Task<bool> DeleteFeriadoAsync(byte id);
}