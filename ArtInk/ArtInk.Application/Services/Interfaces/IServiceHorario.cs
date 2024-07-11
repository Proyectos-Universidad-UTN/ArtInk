using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceHorario
{
    Task<ICollection<HorarioDTO>> ListAsync();

    Task<HorarioDTO> FindByIdAsync(short id);

    Task<HorarioDTO> CreateHorarioAsync(RequestHorarioDTO horarioDTO);

    Task<HorarioDTO> UpdateHorarioAsync(short id, RequestHorarioDTO horarioDTO);
}
