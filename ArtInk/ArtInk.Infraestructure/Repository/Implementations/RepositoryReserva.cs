using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryReserva(ArtInkContext context) : IRepositoryReserva
{
    public async Task<Reserva> CreateReservaAsync(Reserva reserva)
    {
        var result = context.Reservas.Add(reserva);
        await context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Reserva> UpdateReservaAsync(Reserva reserva)
    {
        context.Reservas.Update(reserva);

        await context.SaveChangesAsync();

        var response = await FindByIdAsync(reserva.Id);
        return response!;
    }

    public async Task<Reserva?> FindByIdAsync(int id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Reserva))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<Reserva>()
            .Include(a => a.ReservaServicios)
            .ThenInclude(a => a.IdServicioNavigation)
            .ThenInclude(a => a.IdTipoServicioNavigation)
            .Include(a => a.IdSucursalNavigation)
            .Include(a => a.ReservaPregunta)
            .AsNoTracking()
        .FirstOrDefaultAsync(a => EF.Property<int>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<Reserva>> ListAsync()
    {
        var collection = await context.Set<Reserva>()
            .AsNoTracking()
            .ToListAsync();
        return collection;
    }

    public async Task<bool> ExisteReserva(int id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Reserva))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<Reserva>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<int>(a, keyProperty.Name) == id) != null;
    }

    public async Task<ICollection<Reserva>> ReservaDiaBySucursalAsync(byte idSucursal, DateOnly dia)
    {
        var collection = await context.Set<Reserva>()
            .AsNoTracking()
            .Where(m => m.IdSucursal == idSucursal && m.Fecha == dia )
            .ToListAsync();
        return collection;
    }
}