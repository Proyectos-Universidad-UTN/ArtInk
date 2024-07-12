using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryReservaPregunta
{
    Task<ICollection<ReservaPregunta>> ListAsync();
    Task<ReservaPregunta?> FindByIdAsync(int id);
}
