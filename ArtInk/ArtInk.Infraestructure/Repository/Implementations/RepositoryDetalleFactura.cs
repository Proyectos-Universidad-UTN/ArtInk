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
        public async Task<DetalleFactura?> FindByIdAsync(long id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(DetalleFactura))!.FindPrimaryKey()!.Properties[0];
            return await context.Set<DetalleFactura>()
                .Include(a => a.IdFacturaNavigation)
                .Include(a => a.IdServicioNavigation)
            .FirstOrDefaultAsync(a => EF.Property<int>(a, keyProperty.Name) == id);
        }

        public async Task<ICollection<DetalleFactura>> ListAsync(long idFactura)
        {
            var collection = await context.Set<DetalleFactura>()
                .Include(a => a.IdFacturaNavigation)
                .Include(a => a.IdServicioNavigation)
                .Where(a=> a.IdFactura == idFactura)
                .ToListAsync();
            return collection;
        }
    }
}
