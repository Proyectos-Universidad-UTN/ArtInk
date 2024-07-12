using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryHorario(ArtInkContext context) : IRepositoryHorario
{
    public async Task<Horario> CreateHorarioAsync(Horario horario)
    {
        var result = context.Horarios.Add(horario);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Horario> UpdateHorarioAsync(Horario horario)
    {
        context.Horarios.Update(horario);

        await context.SaveChangesAsync();

        var response = await FindByIdAsync(horario.Id);
        return response!;
    }

    public async Task<Horario?> FindByIdAsync(short id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Horario))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<Horario>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<Horario>> ListAsync()
    {
         var collection = await context.Set<Horario>()
                .AsNoTracking()
                .ToListAsync();
        return collection;
    }

    public async Task<bool> ExisteHorario(short id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Horario))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<Horario>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id) != null;
    }
}