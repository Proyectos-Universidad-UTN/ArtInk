using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Interfaces
{
    public interface IServiceReservaServicio
    {
        Task<ICollection<ReservaServicioDto>> GetServiciosByReservaAsync(int idReserva);

        Task<ReservaServicioDto?> GetReservaServicioByIdAsync(int id);

        Task<bool> CreateReservaServicioAsync(int idReserva, IEnumerable<RequestReservaServicioDto> reservaServicios);
    }
}
