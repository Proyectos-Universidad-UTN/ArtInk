using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryCanton
    {
        Task<ICollection<Canton>> ListAsync(byte idProvincia);
        
        Task<Canton?> FindByIdAsync(byte id);
    }
}