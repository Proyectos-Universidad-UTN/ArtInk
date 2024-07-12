using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceHorario
{
    Task<ICollection<HorarioDto>> ListAsync();

    Task<HorarioDto> FindByIdAsync(short id);

    Task<HorarioDto> CreateHorarioAsync(RequestHorarioDto horarioDTO);

    Task<HorarioDto> UpdateHorarioAsync(short id, RequestHorarioDto horarioDTO);
}