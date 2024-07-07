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
        Task<ICollection<SucursalHorario>> GetSucursalHorarioBySucursalAsync(byte idSucursal);

        Task<SucursalHorario> CreateSucursalHorarioAsync(SucursalHorario sucursalHorario);

        Task<IEnumerable<SucursalHorario>> CreateSucursalHorarioAsync(byte idSucursal, IEnumerable<SucursalHorario> sucursalHorarios);

        Task<SucursalHorario> UpdateSucursalHorarioAsync(SucursalHorario sucursalHorario);
    }
}
