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
   public class RepositoryDetalleFactura(ArtInkContext context) : IRepositoryDetalleFactura
    {
        public async Task<DetalleFactura?> FindByIdAsync(int id)
        {
            return await context.Set<DetalleFactura>().FindAsync(id);
        }

        public async Task<ICollection<DetalleFactura>> ListAsync()
        {
            var collection = await context.Set<DetalleFactura>()
                .Include(a => a.IdFacturaNavigation)
                .Include(a => a.IdServicioNavigation)
                .ToListAsync();
            return collection;
        }
    }
}
