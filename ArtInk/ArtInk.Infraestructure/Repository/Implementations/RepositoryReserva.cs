using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryReserva(ArtInkContext context) : IRepositoryReserva
{
    public async Task<Reserva?> FindByIdAsync(int id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Reserva))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<Reserva>()
            .Include(a => a.ReservaServicios)
            .ThenInclude(a => a.IdServicioNavigation)
            .Include(a => a.IdSucursalNavigation)
            .Include(a => a.ReservaPregunta)
        .FirstOrDefaultAsync(a => EF.Property<int>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<Reserva>> ListAsync(byte rol)
    {
        var collection = await context.Set<Reserva>()
            .Include(a => a.IdSucursalNavigation)
            .Include(a => a.IdUsuarioSucursalNavigation)
            .ThenInclude(a => a.IdUsuarioNavigation)
            .Where(a => a.IdUsuarioSucursalNavigation.IdUsuarioNavigation.IdRol == rol)
            .ToListAsync();
        return collection;
    }
}