using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceHorario
{
    Task<ICollection<HorarioDTO>> ListAsync();
    Task<ICollection<HorarioDTO>> GetHorariosBySucursalAsync(byte idSucursal);
    Task<HorarioDTO> FindByIdAsync(short id);
}
