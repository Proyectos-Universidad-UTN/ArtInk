using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceReservaPregunta
{
    Task<ICollection<ReservaPreguntaDto>> ListAsync();

    Task<ReservaPreguntaDto> FindByIdAsync(int id);
}