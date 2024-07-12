using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceSucursalFeriado
{
    Task<ICollection<SucursalFeriadoDto>> GetFeriadosBySucursalAsync(byte idSucursal, short? anno);

    Task<SucursalFeriadoDto?> GetSucursalFeriadoByIdAsync(short id);

    Task<bool> CreateSucursalFeriadosAsync(byte idSucursal, IEnumerable<RequestSucursalFeriadoDto> sucursalFeriados);
}