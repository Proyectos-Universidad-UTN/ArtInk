using ArtInk.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Infraestructure.Repository.Interfaces
{
    public interface IRepositorySucursalHorario
    {
        Task<ICollection<SucursalHorario>> GetHorariosBySucursalAsync(byte idSucursal);

        Task<SucursalHorario?> GetSucursalHorarioByIdAsync(short id);

        Task<bool> CreateSucursalHorariosAsync(byte idSucursal, IEnumerable<SucursalHorario> sucursalHorarios);
    }
}
