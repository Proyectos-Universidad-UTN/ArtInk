using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositorySucursalFeriado(ArtInkContext context) : IRepositorySucursalFeriado
{
    public async Task<bool> CreateSucursalFeriadosAsync(byte idSucursal, IEnumerable<SucursalFeriado> sucursalFeriados)
    {
        var result = true;
        var feriadosExistentes = await GetFeriadosBySucursalAsync(idSucursal);
        using var transaccion = context.Database.BeginTransaction();

        try
        {
            context.SucursalFeriados.RemoveRange(feriadosExistentes);
            var rowsAffected = await context.SaveChangesAsync();

            if (rowsAffected == 0)
            {
                await transaccion.RollbackAsync();
                return false;
            }

            context.SucursalFeriados.AddRange(sucursalFeriados);
            rowsAffected = await context.SaveChangesAsync();

            if (rowsAffected == 0)
            {
                await transaccion.RollbackAsync();
                return false;
            }

            await transaccion.CommitAsync();
        }
        catch (Exception)
        {
            await transaccion.RollbackAsync();
            throw new Exception("Error al guardar feriados");
        }

        return result;
    }

    public async Task<ICollection<SucursalFeriado>> GetFeriadosBySucursalAsync(byte idSucursal)
    {
        var collection = await context.Set<SucursalFeriado>()
                .AsNoTracking()
                .Include(m => m.IdFeriadoNavigation)
                .Where(m => m.IdSucursal == idSucursal)
                .ToListAsync();
        return collection;
    }

    public async Task<ICollection<SucursalFeriado>> GetFeriadosBySucursalAsync(byte idSucursal, short anno)
    {
        var collection = await context.Set<SucursalFeriado>()
                .AsNoTracking()
                .Include(m => m.IdFeriadoNavigation)
                .Where(m => m.IdSucursal == idSucursal && m.Ano == anno)
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