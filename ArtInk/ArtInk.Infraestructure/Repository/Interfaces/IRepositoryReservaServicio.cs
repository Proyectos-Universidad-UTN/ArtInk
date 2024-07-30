using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryReservaServicio
    {
        Task<ICollection<ReservaServicio>> GetServiciosByReservaAsync(int idReserva);

        Task<ReservaServicio?> GetReservaServicioByIdAsync(int id);

        Task<bool> CreateReservaServicioAsync(int idReserva, IEnumerable<ReservaServicio> reservaServicios);
    }
}
