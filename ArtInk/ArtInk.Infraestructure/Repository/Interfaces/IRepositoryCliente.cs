using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryCliente
{
    Task<ICollection<Cliente>> ListAllAsync();
}