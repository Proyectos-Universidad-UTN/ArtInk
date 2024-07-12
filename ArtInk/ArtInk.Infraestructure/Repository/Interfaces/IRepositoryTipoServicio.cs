using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryTipoServicio
{
    Task<ICollection<TipoServicio>> ListAsync();

    Task<TipoServicio?> FindByIdAsync(byte id);
}
