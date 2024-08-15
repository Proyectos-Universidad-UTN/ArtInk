using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositorySucursal
{
    Task<Sucursal> CreateSucursalAsync(Sucursal sucursal);

    Task<Sucursal> UpdateSucursalAsync(Sucursal sucursal);

    Task<ICollection<Sucursal>> ListAsync();

    Task<ICollection<Sucursal>> ListAsync(string rol);

    Task<Sucursal?> FindByIdAsync(byte id);

    Task<bool> ExisteSucursal(byte id);
}