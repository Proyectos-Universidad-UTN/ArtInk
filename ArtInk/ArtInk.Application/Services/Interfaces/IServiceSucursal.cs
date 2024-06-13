using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceSucursal
    {
        Task<ICollection<SucursalDTO>> ListAsync();
        Task<SucursalDTO> FindByIdAsync(byte id);
    }
}