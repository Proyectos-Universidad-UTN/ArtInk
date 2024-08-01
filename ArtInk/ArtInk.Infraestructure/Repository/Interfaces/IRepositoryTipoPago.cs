using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryTipoPago
{
    Task<ICollection<TipoPago>> ListAllAsync();
}