using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryReserva
{
    Task<ICollection<Reserva>> ListAsync(byte rol);
    Task<Reserva?> FindByIdAsync(int id);
}
