using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Infraestructure.Repository.Implementations;

public class RepositoryImpuesto(ArtInkContext context) : IRepositoryImpuesto
{
    public async Task<ICollection<Impuesto>> ListAllAsync() => await context.Set<Impuesto>().AsNoTracking().ToListAsync();
}