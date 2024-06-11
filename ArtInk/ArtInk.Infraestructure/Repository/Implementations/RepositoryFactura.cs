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
        public async Task<Factura?> FindByIdAsync(int id)
        {
            return await context.Set<Factura>().FindAsync(id);
        }

        public async Task<ICollection<Factura>> ListAsync()
        {
            var collection = await context.Set<Factura>()
                .Include(a => a.IdClienteNavigation)
                .Include(a => a.IdTipoPagoNavigation)
                .Include(a => a.IdImpuestoNavigation)
                .Include(a => a.IdUsuarioSucursalNavigation)
                .ToListAsync();
            return collection;
        }
    }
}
