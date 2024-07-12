using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryServicio(ArtInkContext context) : IRepositoryServicio
{
    public async Task<Servicio> CreateServicioAsync(Servicio servicio)
    {
        var result = context.Servicios.Add(servicio);
        //aplica en la BD
        await context.SaveChangesAsync();
        //Refleja la entidad
        return result.Entity;
    }

    public async Task<bool> ExisteServicio(byte id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Servicio))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<Servicio>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id) != null;
    }

    public async Task<Servicio?> FindByIdAsync(byte id)
    {
        return await context.Set<Servicio>().FindAsync(id);
    }

    public async Task<ICollection<Servicio>> ListAsync()
    {
        var collection = await context.Set<Servicio>()
       .Include(a => a.IdTipoServicioNavigation)
       .ToListAsync();
        return collection;
    }

    public async Task<Servicio> UpdateServicioAsync(Servicio servicio)
    {
        context.Servicios.Update(servicio);

        await context.SaveChangesAsync();

        var response = await FindByIdAsync(servicio.Id);
        return response!;
    }
}