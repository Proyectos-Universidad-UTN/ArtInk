﻿
using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryUsuario(ArtInkContext context) : IRepositoryUsuario
{
    /// <summary>
    /// Busca el usuario por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Usuario?> FindByIdAsync(short id)
    {
        return await context.Set<Usuario>().FindAsync(id);
    }

    public async Task<Usuario?> FindByEmailAsync(string correoElectronico)
    {
        return await context.Set<Usuario>().Include(m => m.IdRolNavigation).AsNoTracking().FirstOrDefaultAsync(m => m.CorreoElectronico == correoElectronico);
    }

    /// <summary>
    /// Este metodo devuelve Colección de usuarios
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<Usuario>> ListAsync()
    {
        var collection = await context.Set<Usuario>()
            .Include(a => a.IdRolNavigation)
            .AsNoTracking()
            .ToListAsync();
        return collection;
    }

    public async Task<ICollection<Usuario>> ListAsync(byte idRol)
    {
        var collection = await context.Set<Usuario>()
            .Include(a => a.IdRolNavigation)
            .AsNoTracking()
            .Where(m => m.IdRol == idRol)
            .ToListAsync();
        return collection;
    }

    public async Task<Usuario?> LoginAsync(string correoElectronico, string contrasenna)
    {
        return await context.Set<Usuario>().Include(m => m.IdRolNavigation).AsNoTracking().FirstOrDefaultAsync(m => m.CorreoElectronico == correoElectronico && m.Contrasenna == contrasenna);
    }

    public async Task<bool> LibreAsignacionSucursal(short id, byte idSucursalAsignacion) => !await context.Set<UsuarioSucursal>().AsNoTracking().AnyAsync(m => m.IdUsuario == id && m.IdSucursal != idSucursalAsignacion);

    public async Task<bool> ExistsByIdAsync(short id)
    {
        var keyProperty = context.Model.FindEntityType(typeof(Usuario))!.FindPrimaryKey()!.Properties[0];

        return await context.Set<Usuario>()
            .AsNoTracking()
            .FirstOrDefaultAsync(a => EF.Property<short>(a, keyProperty.Name) == id) != null;
    }
}