using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceSucursalFeriado
{
    Task<ICollection<SucursalFeriadoDTO>> GetFeriadosBySucursalAsync(byte idSucursal, short? anno);

    Task<SucursalFeriadoDTO?> GetSucursalFeriadoByIdAsync(short id);

    Task<bool> CreateSucursalFeriadosAsync(byte idSucursal, IEnumerable<RequestSucursalFeriadoDTO> sucursalFeriados);
}