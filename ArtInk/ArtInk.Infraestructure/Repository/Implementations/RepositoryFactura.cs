using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryFactura(ArtInkContext context) : IRepositoryFactura
{
    public async Task<Factura> CreateFacturaAsync(Factura factura)
    {
        Factura result = null!;
        var executionStrategy = context.Database.CreateExecutionStrategy();

        await executionStrategy.Execute(async () =>
        {
            using var transaccion = await context.Database.BeginTransactionAsync();
            try
            {
                var tracking = context.Facturas.Add(factura);
                var filasAfectadas = await context.SaveChangesAsync();

                if (filasAfectadas == 0)
                {
                    await transaccion.RollbackAsync();
                    throw (new Exception("No se ha podido guardar la factura") as SqlException)!;
                }

                var pedido = await context.Pedidos.FindAsync(factura.IdPedido);
                if (pedido != null)
                {
                    pedido.Estado = 'F';

                    context.Pedidos.Update(pedido);

                    filasAfectadas = await context.SaveChangesAsync();

                    if (filasAfectadas == 0)
                    {
                        await transaccion.RollbackAsync();
                        throw (new Exception("No se ha podido actualizar la factura") as SqlException)!;
                    }
                }
                
                result = tracking.Entity;
                await transaccion.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaccion.RollbackAsync();
                throw new RequestFailedException(ex.Message, ex);
            }

        });

        return result;
    }

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
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<long>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<Factura>> ListAsync()
    {
        var collection = await context.Set<Factura>()
            .AsNoTracking()
            .ToListAsync();
        return collection;
    }
}