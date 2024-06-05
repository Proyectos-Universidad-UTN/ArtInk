using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositorySucursal(ArtInkContext context) : IRepositorySucursal
{
    public async Task<Sucursal?> CreateAsync(Sucursal sucursal)
    {
        context.Set<Sucursal>().Add(sucursal);

        var rowsAffected = await context.SaveChangesAsync();

        return rowsAffected > 0 ? sucursal : null;
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        var sucursal = await GetByIdAsync(id);
        context.Set<Sucursal>().Remove(sucursal!);

        var rowsAffected = await context.SaveChangesAsync();

        return rowsAffected > 0;
    }

    public async Task<bool> ExistsAsync(byte id) => await context.Set<Sucursal>().FindAsync(id) != null;
    public async Task<Sucursal?> GetByIdAsync(byte id) => await context.Set<Sucursal>().FindAsync(id);

    public async Task<ICollection<Sucursal>> ListAsync() => await context.Set<Sucursal>().ToListAsync();

    public async Task<Sucursal?> UpdateAsync(Sucursal sucursal)
    {
        context.Set<Sucursal>().Update(sucursal);

        var rowsAffected = await context.SaveChangesAsync();

        return rowsAffected > 0 ? sucursal : null;
    }
}