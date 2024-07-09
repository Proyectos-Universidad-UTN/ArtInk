using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryFeriado(ArtInkContext context) : IRepositoryFeriado
{
    public async Task<Feriado> CreateFeriadoAsync(Feriado feriado)
    {
        var result = context.Feriados.Add(feriado);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> DeleteFeriadoAsync(byte id)
    {
        var feriado = await FindByIdAsync(id);
        feriado!.Activo = false;

        context.Feriados.Update(feriado);

        var rowsAffected = await context.SaveChangesAsync();
        return rowsAffected > 0;
    }

    public async Task<bool> ExisteFeriadoAsync(byte id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Feriado))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<Feriado>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id && a.Activo) != null;
    }

    public async Task<Feriado?> FindByIdAsync(byte id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Feriado))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<Feriado>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id && a.Activo);
    }

    public async Task<ICollection<Feriado>> ListAsync()
    {
        var collection = await context.Set<Feriado>()
                .Where(m => m.Activo)
                .AsNoTracking()
                .ToListAsync();
        return collection;
    }

    public async Task<Feriado> UpdateFeriadoAsync(Feriado feriado)
    {
        context.Feriados.Update(feriado);

        await context.SaveChangesAsync();

        var response = await FindByIdAsync(feriado.Id);
        return response!;
    }
}