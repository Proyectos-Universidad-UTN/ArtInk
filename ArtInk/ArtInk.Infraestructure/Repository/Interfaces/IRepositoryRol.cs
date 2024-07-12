using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryRol
{
    Task<ICollection<Rol>> ListAsync();
    Task<Rol?> FindByIdAsync(byte id);
}
