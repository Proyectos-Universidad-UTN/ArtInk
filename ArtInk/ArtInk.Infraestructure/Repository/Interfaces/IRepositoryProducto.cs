using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryProducto
{
    Task<Producto> CreateProductoAsync(Producto producto);

    Task<Producto> UpdateProductoAsync(Producto producto);

    Task<ICollection<Producto>> ListAsync();

    Task<Producto?> FindByIdAsync(short id);

    Task<bool> ExisteProducto(short id);
}
