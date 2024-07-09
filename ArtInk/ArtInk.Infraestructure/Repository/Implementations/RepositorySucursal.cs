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
        public async Task<Sucursal> CreateSucursalAsync(Sucursal sucursal)
        {
            var result = context.Sucursals.Add(sucursal);
            //aplica en la BD
            await context.SaveChangesAsync();
            //Refleja la entidad
            return result.Entity;
        }

        public async Task<Sucursal> UpdateSucursalAsync(Sucursal sucursal)
        {
            context.Sucursals.Update(sucursal);

            await context.SaveChangesAsync();

            var response = await FindByIdAsync(sucursal.Id);
            return response!;
        }

        public async Task<Sucursal?> FindByIdAsync(byte id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Sucursal))!.FindPrimaryKey()!.Properties[0];

            return await context.Set<Sucursal>()
                .AsNoTracking()
                .Include(m => m.IdDistritoNavigation)
                .ThenInclude(m => m.IdCantonNavigation)
                .ThenInclude(m => m.IdProvinciaNavigation)
                .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id);
        }

        public async Task<bool> ExisteSucursal(byte id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Sucursal))!.FindPrimaryKey()!.Properties[0];

            return await context.Set<Sucursal>()
                .AsNoTracking()
                .FirstOrDefaultAsync(a => EF.Property<byte>(a, keyProperty.Name) == id) != null;
        }

        public async Task<ICollection<Sucursal>> ListAsync()
        {
            var collection = await context.Set<Sucursal>()
                .AsNoTracking()
                .Include(a => a.IdDistritoNavigation)
                .ThenInclude(m => m.IdCantonNavigation)
                .ThenInclude(m => m.IdProvinciaNavigation)
                .ToListAsync();
            return collection;
        }
    }
}
