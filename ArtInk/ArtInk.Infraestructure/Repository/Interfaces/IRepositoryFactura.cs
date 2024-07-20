using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryFactura
{
    Task<Factura> CreateFacturaAsync(Factura factura);
    Task<ICollection<Factura>> ListAsync();
    Task<Factura?> FindByIdAsync(long id);

}
