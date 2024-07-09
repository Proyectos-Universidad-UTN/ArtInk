using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryUnidadMedida
    {
        Task<ICollection<UnidadMedida>> ListAsync();
        Task<UnidadMedida?> FindByIdAsync(byte id);

    }
}
