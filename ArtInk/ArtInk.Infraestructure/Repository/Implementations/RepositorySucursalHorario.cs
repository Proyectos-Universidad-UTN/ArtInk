using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositorySucursalHorario(ArtInkContext context) : IRepositorySucursalHorario
{
    public async Task<bool> CreateSucursalHorariosAsync(byte idSucursal, IEnumerable<SucursalHorario> sucursalHorarios)
    {
        var result = true;
        var horariosExistentes = await GetHorariosBySucursalAsync(idSucursal);

        var executionStrategy = context.Database.CreateExecutionStrategy();

        await executionStrategy.Execute(async () =>
        {
            using var transaccion = await context.Database.BeginTransactionAsync();
            try
            {
                context.SucursalHorarios.RemoveRange(horariosExistentes);
                var rowsAffected = await context.SaveChangesAsync();

                if (rowsAffected == 0 && horariosExistentes.Count != 0)
                {
                    await transaccion.RollbackAsync();
                    result = false;
                }
                else
                {
                    context.SucursalHorarios.AddRange(sucursalHorarios);
                    rowsAffected = await context.SaveChangesAsync();

                    if (rowsAffected == 0)
                    {
                        await transaccion.RollbackAsync();
                        result = false;
                    }
                    else
                    {
                        await transaccion.CommitAsync();
                    }
                }
            }
            catch (Exception exc)
            {
                await transaccion.RollbackAsync();
                throw new RequestFailedException("Error al guardar horarios", exc);
            }
        });

        return result;
    }

    public async Task<ICollection<SucursalHorario>> GetHorariosBySucursalAsync(byte idSucursal)
    {
        var collection = await context.Set<SucursalHorario>()
           .AsNoTracking()
           .Include(m => m.IdHorarioNavigation)
           .Where(m => m.IdSucursal == idSucursal)
           .ToListAsync();
        return collection;
    }


    public async Task<SucursalHorario?> GetSucursalHorarioByIdAsync(short id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(SucursalHorario))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<SucursalHorario>()
                .Include(m => m.IdHorarioNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name) == id);
    }
}
