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
    public class RepositorySucursal(ArtInkContext context) : IRepositorySucursal
    {
        public async Task<Sucursal?> FindByIdAsync(byte id)
        {
            return await context.Set<Sucursal>().FindAsync(id);
        }

        public async Task<ICollection<Sucursal>> ListAsync()
        {
            var collection = await context.Set<Sucursal>()
                .Include(a => a.IdDistritoNavigation) 
                .ToListAsync();
            return collection;
        }
    }
}
