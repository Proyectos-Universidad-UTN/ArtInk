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
        Task<ICollection<SucursalHorarioBloqueoDto>> GetSucursalHorarioBloqueosBySucursalHorarioAsync(short idSucursalHorario);

        Task<SucursalHorarioBloqueoDto> GetSucursalHorarioBloqueosByIdAsync(long id);

        Task<SucursalHorarioBloqueoDto> CreateSucursalHorarioBloqueoAsync(RequestSucursalHorarioBloqueoDto bloqueoDTO);

        Task<SucursalHorarioBloqueoDto> UpdateSucursalHorarioBloqueoAsync(long id, RequestSucursalHorarioBloqueoDto bloqueoDTO);
    }
}