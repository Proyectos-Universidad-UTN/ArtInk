using ArtInk.Infraestructure.Data;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Implementations
{
    public class RepositoryCategoria (ArtInkContext context) : IRepositoryCategoria
    {    
        public async Task<Categoria?> FindByIdAsync(byte id)
        {
            return await context.Set<Categoria>().FindAsync(id);
        }

        public async Task<ICollection<Categoria>> ListAsync()
        {
            var collection = await context.Set<Categoria>().ToListAsync();
            return collection;
        }
    }
}
