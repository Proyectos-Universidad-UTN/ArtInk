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
    public class RepositoryFactura(ArtInkContext context) : IRepositoryFactura
    {
        public async Task<Factura?> FindByIdAsync(long id)
        {
            var keyProperty = context.Model.FindEntityType(typeof(Factura))!.FindPrimaryKey()!.Properties[0];
            return await context.Set<Factura>()
                .Include(a => a.IdClienteNavigation)
                .Include(a => a.IdTipoPagoNavigation)
                .Include(a => a.IdImpuestoNavigation)
                .Include(a => a.IdUsuarioSucursalNavigation)
                .ThenInclude(a => a.IdSucursalNavigation)
                .Include(a => a.DetalleFacturas)
                .ThenInclude(a => a.IdServicioNavigation)
                .Include(a => a.DetalleFacturas)
                .ThenInclude(a => a.DetalleFacturaProductos)
                .ThenInclude(a => a.IdProductoNavigation)
                .FirstOrDefaultAsync(a => EF.Property<long>(a, keyProperty.Name) == id);
        }

        public async Task<ICollection<Factura>> ListAsync()
        {
            var collection = await context.Set<Factura>()
                .ToListAsync();
            return collection;
        }
    }
}
