using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryDetallePedido(ArtInkContext context) : IRepositoryDetallePedido
{
    public async Task<DetallePedido?> FindByIdAsync(long idPedido, long id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(DetallePedido))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<DetallePedido>()
            .Include(a => a.IdPedidoNavigation)
            .Include(a => a.IdServicioNavigation)
            .Where(a => a.IdPedido == idPedido)
            .AsNoTracking()
        .FirstOrDefaultAsync(a => EF.Property<long>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<DetallePedido>> ListAsync(long idPedido)
    {
        var collection = await context.Set<DetallePedido>()
            .Include(a => a.IdPedidoNavigation)
            .Include(a => a.IdServicioNavigation)
            .Where(a => a.IdPedido == idPedido)
            .AsNoTracking()
            .ToListAsync();
        return collection;
    }
}
