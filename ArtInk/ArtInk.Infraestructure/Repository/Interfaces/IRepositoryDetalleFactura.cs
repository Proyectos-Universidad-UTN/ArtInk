using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryDetalleFactura
{
    Task<DetalleFactura?> FindByIdAsync(long idFactura, long id);
    Task<ICollection<DetalleFactura>> ListAsync(long idFactura);
}
