using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositoryHorario
    {
        Task<ICollection<Horario>> ListAsync();
        Task<Horario?> FindByIdAsync(short id);
    }
}
