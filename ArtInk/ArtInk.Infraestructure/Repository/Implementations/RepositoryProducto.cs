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
    public class RepositoryProducto(ArtInkContext context) : IRepositoryProducto
    {
        public async Task<Producto> CreateProductoAsync(Producto producto)
        {
            var result= context.Productos.Add(producto);
            //aplica en la BD
            await context.SaveChangesAsync();
            //Refleja la entidad
            return result.Entity;
        }

        public async Task<Producto> UpdateProductoAsync(Producto producto)
        {
            context.Productos.Update(producto);

            await context.SaveChangesAsync();

            var response = await FindByIdAsync(producto.Id);
            return response!;
        }

        public async Task<Producto?> FindByIdAsync(short id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Producto))!.FindPrimaryKey()!.Properties[0];
            return await context.Set<Producto>()
                .Include(a => a.IdUnidadMedidaNavigation)
                .Include(a => a.IdCategoriaNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name)==id);
        }

        public async Task<ICollection<Producto>> ListAsync()
        {
            var collection = await context.Set<Producto>()
                .AsNoTracking()
                .ToListAsync();
            return collection;
        }

        public async Task<bool> ExisteProducto(short id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Producto))!.FindPrimaryKey()!.Properties[0];

            return await context.Set<Producto>()
                .AsNoTracking()
                .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name) == id) != null;
        }
    }
}
