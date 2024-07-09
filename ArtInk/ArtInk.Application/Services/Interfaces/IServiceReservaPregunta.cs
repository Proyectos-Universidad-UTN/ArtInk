using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceReservaPregunta
{
    Task<ICollection<ReservaPreguntaDTO>> ListAsync();

    Task<ReservaPreguntaDTO> FindByIdAsync(int id);
}