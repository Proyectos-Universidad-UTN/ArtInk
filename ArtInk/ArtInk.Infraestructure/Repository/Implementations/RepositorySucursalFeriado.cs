using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositorySucursalFeriado(ArtInkContext context) : IRepositorySucursalFeriado
{
    public async Task<bool> CreateSucursalFeriadosAsync(byte idSucursal, IEnumerable<SucursalFeriado> sucursalFeriados)
    {
        var result = true;
        var feriadosExistentes = await GetFeriadosBySucursalAsync(idSucursal);

        var executionStrategy = context.Database.CreateExecutionStrategy();

        await executionStrategy.Execute(async () =>
        {
            using var transaccion = await context.Database.BeginTransactionAsync();
            try
            {
                context.SucursalFeriados.RemoveRange(feriadosExistentes);
                var rowsAffected = await context.SaveChangesAsync();

                if (rowsAffected == 0 && feriadosExistentes.Count != 0)
                {
                    await transaccion.RollbackAsync();
                    result = false;
                }
                else
                {
                    context.SucursalFeriados.AddRange(sucursalFeriados);
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
                throw new RequestFailedException("Error al guardar feriados", exc);
            }

        });

        return result;
    }

    public async Task<ICollection<SucursalFeriado>> GetFeriadosBySucursalAsync(byte idSucursal)
    {
        var collection = await context.Set<SucursalFeriado>()
                .AsNoTracking()
                .Include(m => m.IdFeriadoNavigation)
                .Where(m => m.IdSucursal == idSucursal)
                .AsNoTracking()
                .ToListAsync();
        return collection;
    }

    public async Task<ICollection<SucursalFeriado>> GetFeriadosBySucursalAsync(byte idSucursal, short anno)
    {
        var collection = await context.Set<SucursalFeriado>()
                .AsNoTracking()
                .Include(m => m.IdFeriadoNavigation)
                .Where(m => m.IdSucursal == idSucursal && m.Anno == anno)
                .AsNoTracking()
                .ToListAsync();
        return collection;
    }

    public async Task<SucursalFeriado?> GetSucursalFeriadoByIdAsync(short id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(SucursalFeriado))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<SucursalFeriado>()
                .Include(m => m.IdFeriadoNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name) == id);
    }
}