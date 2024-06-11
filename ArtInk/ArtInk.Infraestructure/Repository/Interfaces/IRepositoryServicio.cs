using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{

    public interface IRepositoryServicio
    {
        Task<ICollection<Servicio>> ListAsync();
        Task<Servicio?> FindByIdAsync(byte id);
    }

}
