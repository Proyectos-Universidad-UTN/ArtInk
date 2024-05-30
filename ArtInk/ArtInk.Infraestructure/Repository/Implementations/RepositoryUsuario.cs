
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
    public  class RepositoryUsuario(ArtInkContext context ) : IRepositoryUsuario
    {
        public async Task<Usuario> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Usuario>> ListAsync()
        {
            var collection = await context.Set<Usuario>().ToListAsync();
            return collection;
        }
    }
}
