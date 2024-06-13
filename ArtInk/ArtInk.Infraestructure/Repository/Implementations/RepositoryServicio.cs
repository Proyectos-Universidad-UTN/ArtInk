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
    public class RepositoryServicio(ArtInkContext context) : IRepositoryServicio
    {
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
    }
}
