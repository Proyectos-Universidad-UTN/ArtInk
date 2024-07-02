using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryDistrito
    {
        Task<ICollection<Distrito>> ListAsync(byte idCanton);

        Task<Distrito?> FindByIdAsync(byte id);
    }
}
