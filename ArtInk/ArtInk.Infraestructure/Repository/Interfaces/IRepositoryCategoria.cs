using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryCategoria
{
    Task<ICollection<Categoria>> ListAsync();
    Task<Categoria?> FindByIdAsync(byte id);
}