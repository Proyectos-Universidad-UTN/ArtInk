using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryRol(ArtInkContext context) : IRepositoryRol
{
    public async Task<Rol?> FindByIdAsync(byte id)
    {
        return await context.Set<Rol>().FindAsync(id);
    }

    public async Task<ICollection<Rol>> ListAsync()
    {
        var collection = await context.Set<Rol>().AsNoTracking().ToListAsync();
        return collection;
    }
}