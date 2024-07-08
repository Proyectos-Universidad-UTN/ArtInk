using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceReserva
{
    Task<ICollection<ReservaDTO>> ListAsync(string rol);

    Task<ReservaDTO> FindByIdAsync(int id);
}
