
using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryCliente(ArtInkContext context) : IRepositoryCliente
{
    public async Task<ICollection<Cliente>> ListAllAsync() => await context.Set<Cliente>().AsNoTracking().ToListAsync();
}