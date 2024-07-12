using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryDistrito
{
    Task<ICollection<Distrito>> ListAsync(byte idCanton);

    Task<Distrito?> FindByIdAsync(byte id);
}