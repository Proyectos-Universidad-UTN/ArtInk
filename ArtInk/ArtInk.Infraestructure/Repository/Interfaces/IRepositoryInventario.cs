using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryInventario
{
    Task<Inventario> CreateInventarioAsync(Inventario inventario);

    Task<Inventario> UpdateInventarioAsync(Inventario inventario);

    Task<ICollection<Inventario>> ListAsync();

    Task<ICollection<Inventario>> ListAsync(byte idSucursal);

    Task<Inventario?> FindByIdAsync(short id);

    Task<bool> ExisteInventario(short id);

    Task<bool> DeleteInventarioAsync(short id);
}