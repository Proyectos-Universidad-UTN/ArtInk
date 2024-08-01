﻿using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryProducto(ArtInkContext context) : IRepositoryProducto
{
    public async Task<Producto> CreateProductoAsync(Producto producto)
    {
        var result = context.Productos.Add(producto);
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
            .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name) == id);
    }

    public async Task<ICollection<Producto>> ListAsync(bool excludeProductosInventario = false, short idInventario = 0)
    {
        if (!excludeProductosInventario)
        {
            var collection = await context.Set<Producto>()
            .AsNoTracking()
            .ToListAsync();
            return collection;
        }

        var productosInventarioProducto = from a in context.Productos.AsQueryable()
                        join b in context.InventarioProducto.AsQueryable() on a.Id equals b.IdProducto
                        join c in context.Inventarios.AsQueryable() on b.IdInventario equals c.Id
                        where c.Id == idInventario
                        select a;

        return await context.Set<Producto>().Except(productosInventarioProducto.AsQueryable()).AsNoTracking().ToListAsync();
    }

    public async Task<bool> ExisteProducto(short id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Producto))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<Producto>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name) == id) != null;
    }
}