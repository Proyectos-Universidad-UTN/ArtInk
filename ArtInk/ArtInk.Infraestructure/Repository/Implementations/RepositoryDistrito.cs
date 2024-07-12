using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryDistrito(ArtInkContext context) : IRepositoryDistrito
{
    public async Task<Distrito?> FindByIdAsync(byte id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Distrito))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<Distrito>()
                    .Include(m => m.IdCantonNavigation)
                    .ThenInclude(m => m.IdProvinciaNavigation)
                    .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id);
    }
    public async Task<ICollection<Distrito>> ListAsync(byte idCanton)
    {
        var collection = await context.Set<Distrito>()
            .Where(m => m.IdCanton == idCanton)
            .ToListAsync();
        return collection;
    }
}
