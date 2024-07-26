using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryPedido(ArtInkContext context) : IRepositoryPedido
{
    public async Task<Pedido> CreateFacturaAsync(Pedido pedido)
    {
        var result = context.Pedidos.Add(pedido);
        //aplica en la BD
        await context.SaveChangesAsync();
        //Refleja la entidad
        return result.Entity;
    }

    public async Task<Pedido?> FindByIdAsync(long id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Pedido))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<Pedido>()
            .Include(a => a.IdClienteNavigation)
            .Include(a => a.IdTipoPagoNavigation)
            .Include(a => a.IdImpuestoNavigation)
            .Include(a => a.IdUsuarioSucursalNavigation)
            .ThenInclude(a => a.IdSucursalNavigation)
            .Include(a => a.DetallePedidos)
            .ThenInclude(a => a.IdServicioNavigation)
            .Include(a => a.DetallePedidos)
            .ThenInclude(a => a.DetallePedidoProductos)
            .ThenInclude(a => a.IdProductoNavigation)
            .FirstOrDefaultAsync(a => EF.Property<long>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<Pedido>> ListAsync()
    {
        var collection = await context.Set<Pedido>()
            .ToListAsync();
        return collection;
    }
}