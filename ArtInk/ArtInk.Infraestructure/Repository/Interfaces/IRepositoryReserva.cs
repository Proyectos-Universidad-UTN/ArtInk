using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryReserva
{
    Task<Reserva> CreateReservaAsync(Reserva reserva);

    Task<Reserva> UpdateReservaAsync(Reserva reserva);

    Task<ICollection<Reserva>> ListAsync();

    Task<Reserva?> FindByIdAsync(int id);

    Task<bool> ExisteReserva(int id);
}
