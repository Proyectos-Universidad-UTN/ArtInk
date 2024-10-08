﻿using System.Data.Common;
using System.Diagnostics;
using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryPedido(ArtInkContext context) : IRepositoryPedido
{
    public async Task<Pedido> CreatePedidoAsync(Pedido pedido, Reserva reserva)
    {
        Pedido result = null!;
        var executionStrategy = context.Database.CreateExecutionStrategy();

        await executionStrategy.Execute(async () =>
        {
            using var transaccion = await context.Database.BeginTransactionAsync();
            try
            {
                var tracking = context.Pedidos.Add(pedido);
                var filasAfectadas = await context.SaveChangesAsync();

                if (filasAfectadas == 0)
                {
                    await transaccion.RollbackAsync();
                    throw (new Exception("No se ha podido guardar el pedido") as SqlException)!;
                }

                context.Reservas.Update(reserva);

                filasAfectadas = await context.SaveChangesAsync();

                if (filasAfectadas == 0)
                {
                    await transaccion.RollbackAsync();
                    throw (new Exception("No se ha podido actualizar la reserva") as SqlException)!;
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

    public async Task<bool> ExisteFacturaAsync(long id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Pedido))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<Pedido>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<long>(a, keyProperty.Name) == id) != null;
    }

    public async Task<Pedido?> FindByIdAsync(long id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Pedido))!.FindPrimaryKey()!.Properties[0];
        return await context.Set<Pedido>()
            .Include(a => a.IdClienteNavigation)
            .Include(a => a.IdTipoPagoNavigation)
            .Include(a => a.IdImpuestoNavigation)
            .Include(a => a.IdSucursalNavigation)
            .Include(a => a.DetallePedidos)
            .ThenInclude(a => a.IdServicioNavigation)
            .ThenInclude(a => a.IdTipoServicioNavigation)
            .Include(a => a.DetallePedidos)
            .ThenInclude(a => a.DetallePedidoProductos)
            .ThenInclude(a => a.IdProductoNavigation)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<long>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<Pedido>> ListAsync()
    {
        var collection = await context.Set<Pedido>()
            .Include(a => a.IdTipoPagoNavigation)
            .AsNoTracking()
            .ToListAsync();
        return collection;
    }
}