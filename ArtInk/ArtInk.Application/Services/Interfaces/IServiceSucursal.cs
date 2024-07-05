using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceSucursal
    {
        Task<ICollection<SucursalDTO>> ListAsync();

        Task<SucursalDTO> FindByIdAsync(byte id);

        Task<SucursalDTO> CreateSucursalAsync(RequestSucursalDTO sucursalDTO);

        Task<SucursalDTO> UpdateSucursalAsync(byte id, RequestSucursalDTO sucursalDTO);
    }
}