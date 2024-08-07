﻿using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryUnidadMedida(ArtInkContext context) : IRepositoryUnidadMedida
{
    public async Task<UnidadMedida?> FindByIdAsync(byte id)
    {
        return await context.Set<UnidadMedida>().FindAsync(id);
    }

    public async Task<ICollection<UnidadMedida>> ListAsync()
    {
        //AsQueryable hace el acceso más sencillo
        var collection = from unidades in context.Set<UnidadMedida>().AsQueryable()
                         select unidades;
        return await collection.AsNoTracking().ToListAsync();
    }
}