using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryDetallePedido
{
    Task<DetallePedido?> FindByIdAsync(long idPedido, long id);
    Task<ICollection<DetallePedido>> ListAsync(long idPedido);
}
