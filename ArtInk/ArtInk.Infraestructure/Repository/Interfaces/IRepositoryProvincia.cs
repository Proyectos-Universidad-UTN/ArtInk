using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryProvincia
{
    Task<ICollection<Provincia>> ListAsync();
    Task<Provincia?> FindByIdAsync(byte id);
}
