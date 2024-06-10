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
            return await context.Set<Reserva>().FindAsync(id);
        }


        public async Task<ICollection<Reserva>> ListAsync()
        {
            var collection = await context.Set<Reserva>()
                .Include(a => a.IdSucursalHorarioNavigation)
                .ToListAsync();
            return collection;
        }
    }
}
