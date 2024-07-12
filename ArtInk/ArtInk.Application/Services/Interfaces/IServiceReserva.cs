using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceReserva
{
    Task<ICollection<ReservaDto>> ListAsync(string rol);

    Task<ReservaDto> FindByIdAsync(int id);
}