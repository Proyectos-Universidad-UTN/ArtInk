using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceFeriado
{
    Task<ICollection<FeriadoDto>> ListAsync();

    Task<FeriadoDto> FindByIdAsync(byte id);

    Task<FeriadoDto> CreateFeriadoAsync(RequestFeriadoDto feriadoDTO);

    Task<FeriadoDto> UpdateFeriadoAsync(byte id, RequestFeriadoDto feriadoDTO);

    Task<bool> DeleteFeriadoAsync(byte id);
}