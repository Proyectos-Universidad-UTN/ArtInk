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
    public class RepositoryHorario(ArtInkContext context) : IRepositoryHorario
    {
        public async Task<Horario?> FindByIdAsync(short id)
        {
            return await context.Set<Horario>().FindAsync(id);
        }

        public  async Task<ICollection<Horario>> ListAsync()
        {
            var collection = await context.Set<Horario>()
             .Include(a => a.IdSucursalNavigation)
             .ToListAsync();
            return collection;
        }
    }
}


