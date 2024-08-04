using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryProveedor
{
    Task<ICollection<Proveedor>> ListAllAsync();

    IQueryable<Proveedor> ListAllQueryable();

    Task<Proveedor?> GetByIdAsync(byte id);

    Task<bool> ExisteProveedor(byte id);

    Task<Proveedor> CreateProveedorAsync(Proveedor proveedor);

    Task<Proveedor> UpdateProveedorAsync(Proveedor proveedor);

    Task<bool> DeleteProveedorAsync(byte id);
}