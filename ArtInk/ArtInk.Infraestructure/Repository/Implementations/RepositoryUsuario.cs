
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

    /// <summary>
    /// Este metodo devuelve Colección de usuarios
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<Usuario>> ListAsync()
    {
        var collection = await context.Set<Usuario>()
            .Include(a => a.IdRolNavigation)
            .ToListAsync();
        return collection;
    }
}