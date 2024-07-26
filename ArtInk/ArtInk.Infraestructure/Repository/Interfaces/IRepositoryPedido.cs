using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryPedido
{
    Task<Pedido> CreateFacturaAsync(Pedido pedido);
    Task<ICollection<Pedido>> ListAsync();
    Task<Pedido?> FindByIdAsync(long id);

}
