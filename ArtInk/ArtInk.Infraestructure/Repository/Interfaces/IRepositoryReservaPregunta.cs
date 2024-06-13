using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryReservaPregunta
    {
        Task<ICollection<ReservaPregunta>> ListAsync();
        Task<ReservaPregunta?> FindByIdAsync(int id);
    }
}
