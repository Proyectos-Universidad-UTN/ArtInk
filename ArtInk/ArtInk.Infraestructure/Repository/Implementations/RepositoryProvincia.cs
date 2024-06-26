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
    public class RepositoryProvincia(ArtInkContext context) : IRepositoryProvincia
    {
        public async Task<Provincia?> FindByIdAsync(byte id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Provincia))!.FindPrimaryKey()!.Properties[0];
            return await context.Set<Provincia>()
                .Include(a => a.Cantons)
                .ThenInclude(a => a.Distritos)
                .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id);
        }

        public async Task<ICollection<Provincia>> ListAsync()
        {
            var collection = await context.Set<Provincia>()
                .Include(a => a.Cantons)
                .ThenInclude(a => a.Distritos)
                .ToListAsync();
            return collection;
        }
    }
}