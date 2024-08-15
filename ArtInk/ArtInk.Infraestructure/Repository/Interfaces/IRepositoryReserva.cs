using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryReserva
{
    Task<Reserva> CreateReservaAsync(Reserva reserva);

    Task<Reserva> UpdateReservaAsync(Reserva reserva);

    Task<ICollection<Reserva>> ListAsync();

    Task<ICollection<Reserva>> ListAsync(byte idSucursal);

    Task<ICollection<Reserva>> ListAsync(byte idSucursal, DateOnly fechaInicio, DateOnly fechaFin);

    Task<ICollection<Reserva>> ReservaDiaBySucursalAsync(byte idSucursal, DateOnly dia);

    Task<Reserva?> FindByIdAsync(int id);

    Task<bool> ExisteReserva(int id);

}
