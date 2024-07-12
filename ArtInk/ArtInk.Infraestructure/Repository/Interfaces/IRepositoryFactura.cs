using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryFactura
{
    Task<ICollection<Factura>> ListAsync();
    Task<Factura?> FindByIdAsync(long id);

}
