using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Infraestructure.Models;


namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceSucursalHorario
    {
        Task<ICollection<SucursalHorarioDTO>> GetHorariosBySucursalAsync(byte idSucursal);

        Task<SucursalHorarioDTO?> GetSucursalHorarioByIdAsync(short id);

        Task<bool> CreateSucursalHorarioAsync(byte idSucursal, IEnumerable<RequestSucursalHorarioDTO> sucursalHorarios);
    }
}
