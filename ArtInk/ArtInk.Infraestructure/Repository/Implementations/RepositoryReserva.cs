using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Implementations
{
    public class RepositoryReserva(ArtInkContext context) : IRepositoryReserva
    {
        public async Task<Reserva?> FindByIdAsync(int id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Reserva))!.FindPrimaryKey()!.Properties[0];
            return await context.Set<Reserva>()
                .Include(a => a.ReservaServicios)
                .ThenInclude(a => a.IdServicioNavigation)
                .Include(a => a.IdSucursalHorarioNavigation)
                .ThenInclude(a => a.IdHorarioNavigation)
                .Include(a => a.IdSucursalHorarioNavigation)
                .ThenInclude(a => a.IdSucursalNavigation)
                .Include(a => a.ReservaPregunta)
            .FirstOrDefaultAsync(a => EF.Property<int>(a, keyProperty.Name) == id);
        }


        public async Task<ICollection<Reserva>> ListAsync()
        {
            var collection = await context.Set<Reserva>()
                .Include(a => a.IdSucursalHorarioNavigation)
                .ThenInclude(a => a.IdSucursalNavigation)
                .Include(a => a.IdSucursalHorarioNavigation)
                .ThenInclude(a => a.IdHorarioNavigation)
                .ToListAsync();
            return collection;
        }
    }
}
