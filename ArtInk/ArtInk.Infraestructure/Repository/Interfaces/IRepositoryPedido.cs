using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryPedido
{
    Task<Pedido> CreatePedidoAsync(Pedido pedido, Reserva reserva);
    Task<ICollection<Pedido>> ListAsync();
    Task<Pedido?> FindByIdAsync(long id);
    Task<bool> ExisteFacturaAsync(long id);
}
