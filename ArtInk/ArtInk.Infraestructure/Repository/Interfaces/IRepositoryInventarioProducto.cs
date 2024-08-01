using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryInventarioProducto
{
    Task<bool> ExisteInventarioProducto(long id);

    Task<InventarioProducto?> GetInventarioProductoById(long id);

    Task<ICollection<InventarioProducto>> ListByInventarioAsync(short idInventario);

    Task<ICollection<InventarioProducto>> ListByProductoAsync(short idProducto);

    Task<InventarioProducto> AgregarProductoInventario(InventarioProducto inventarioProducto);

    Task<bool> AgregarProductoInventario(IEnumerable<InventarioProducto> inventarioProducto);

    Task<InventarioProducto> UpdateProductoInventario(InventarioProducto inventarioProducto);
}