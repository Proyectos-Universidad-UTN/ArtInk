using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryTipoPago(ArtInkContext context) : IRepositoryTipoPago
{
    public async Task<ICollection<TipoPago>> ListAllAsync() => await context.Set<TipoPago>().AsNoTracking().ToListAsync();
}