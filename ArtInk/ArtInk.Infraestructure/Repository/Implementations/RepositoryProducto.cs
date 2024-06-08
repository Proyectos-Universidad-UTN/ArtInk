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
        public async Task<Producto?> FindByIdAsync(short id)
        {
            return await context.Set<Producto>().FindAsync(id);
        }

        public async Task<ICollection<Producto>> ListAsync()
        {
            var collection = await context.Set<Producto>()
                .Include(a => a.IdUnidadMedidaNavigation)
                .Include(a => a.IdCategoriaNavigation)
                .ToListAsync();
            return collection;
        }
    }
}
