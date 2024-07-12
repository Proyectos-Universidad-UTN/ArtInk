using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryTipoServicio(ArtInkContext context) : IRepositoryTipoServicio
{
    public async Task<TipoServicio?> FindByIdAsync(byte id)
    {
        return await context.Set<TipoServicio>().FindAsync(id);
    }

    public async Task<ICollection<TipoServicio>> ListAsync()
    {
        var collection = await context.Set<TipoServicio>().ToListAsync();
        return collection;
    }
}