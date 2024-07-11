using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceSucursalHorarioBloqueo
    {
        Task<ICollection<SucursalHorarioBloqueoDTO>> GetSucursalHorarioBloqueosBySucursalHorarioAsync(short idSucursalHorario);

        Task<SucursalHorarioBloqueoDTO> GetSucursalHorarioBloqueosByIdAsync(long id);

        Task<SucursalHorarioBloqueoDTO> CreateSucursalHorarioBloqueoAsync(RequestSucursalHorarioBloqueoDTO bloqueoDTO);

        Task<SucursalHorarioBloqueoDTO> UpdateSucursalHorarioBloqueoAsync(long id, RequestSucursalHorarioBloqueoDTO bloqueoDTO);
    }
}
