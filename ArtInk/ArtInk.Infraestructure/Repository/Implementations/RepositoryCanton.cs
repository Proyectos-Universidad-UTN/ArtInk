using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations
{
    public class RepositoryCanton(ArtInkContext context) : IRepositoryCanton
    {
        public async Task<Canton?> FindByIdAsync(byte id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Canton))!.FindPrimaryKey()!.Properties[0];
            return await context.Set<Canton>()
                        .Include(m => m.IdProvinciaNavigation)
                        .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id);
        }

        public async Task<ICollection<Canton>> ListAsync(byte idProvincia)
        {
            var collection = await context.Set<Canton>()
                .Where(m => m.IdProvincia == idProvincia)
                .ToListAsync();
            return collection;
        }
    }
}