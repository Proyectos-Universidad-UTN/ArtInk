using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceSucursal
{
    Task<ICollection<SucursalDto>> ListAsync();

    Task<ICollection<SucursalDto>> ListByRolAsync();

    Task<SucursalDto> FindByIdAsync(byte id);

    Task<SucursalDto> CreateSucursalAsync(RequestSucursalDto sucursalDTO);

    Task<SucursalDto> UpdateSucursalAsync(byte id, RequestSucursalDto sucursalDTO);
}