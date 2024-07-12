using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryServicio
{
    Task<ICollection<Servicio>> ListAsync();

    Task<Servicio?> FindByIdAsync(byte id);

    Task<Servicio> CreateServicioAsync(Servicio servicio);

    Task<Servicio> UpdateServicioAsync(Servicio servicio);

    Task<bool> ExisteServicio(byte id);
}