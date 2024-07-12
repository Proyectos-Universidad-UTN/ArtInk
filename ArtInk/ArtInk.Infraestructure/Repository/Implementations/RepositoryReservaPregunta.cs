using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryReservaPregunta(ArtInkContext context) : IRepositoryReservaPregunta
{
    public async Task<ReservaPregunta?> FindByIdAsync(int id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Producto))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<ReservaPregunta>()
            .Include(a => a.IdReservaNavigation)
            .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name) == id);
    }


    public async Task<ICollection<ReservaPregunta>> ListAsync()
    {
        var collection = await context.Set<ReservaPregunta>()
            .Include(a => a.IdReservaNavigation)
            .ToListAsync();
        return collection;
    }
}