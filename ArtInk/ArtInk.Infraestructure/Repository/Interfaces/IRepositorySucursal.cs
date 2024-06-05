using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositorySucursal
{
    Task<ICollection<Sucursal>> ListAsync();

    Task<Sucursal?> GetByIdAsync(byte id);

    Task<bool> ExistsAsync(byte id);

    Task<Sucursal?> CreateAsync(Sucursal sucursal);

    Task<Sucursal?> UpdateAsync(Sucursal sucursal);

    Task<bool> DeleteAsync(byte id);
}