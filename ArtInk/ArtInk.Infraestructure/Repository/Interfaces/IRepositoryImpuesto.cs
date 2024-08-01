using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryImpuesto
{
    Task<ICollection<Impuesto>> ListAllAsync();
}