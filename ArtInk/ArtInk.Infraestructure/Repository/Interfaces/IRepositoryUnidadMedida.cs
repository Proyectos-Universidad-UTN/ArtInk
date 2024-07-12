using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryUnidadMedida
{
    Task<ICollection<UnidadMedida>> ListAsync();

    Task<UnidadMedida?> FindByIdAsync(byte id);
}
