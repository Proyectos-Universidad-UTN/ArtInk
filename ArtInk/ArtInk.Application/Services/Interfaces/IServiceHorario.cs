using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceHorario
{
    Task<ICollection<HorarioDTO>> ListAsync();

    Task<HorarioDTO> FindByIdAsync(short id);
}
