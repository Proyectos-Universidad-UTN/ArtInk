using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Implementations
{
    public class ServiceReserva(IRepositoryReserva repository, IMapper mapper) : IServiceReserva
    {
        /// <summary>
        /// buscarlo por ID
        /// </summary>
        public async Task<ReservaDTO> FindByIdAsync(int id)
        {
            var reserva = await repository.FindByIdAsync(id);
            if (reserva == null) throw new Exception("Reserva no encontrada.");

            return mapper.Map<ReservaDTO>(reserva);
        }

        /// <summary>
        /// Buscar toda la lista
        /// </summary>
        /// <param name="rol">Rol Usuario encargado de reserva</param>
        /// <returns>ICollection<ReservaDTO></returns>
        public async Task<ICollection<ReservaDTO>> ListAsync(string rol)
        {
            RolEnum enumRol;
            if (!Enum.TryParse<RolEnum>(rol, true, out enumRol)) throw new Exception("Rol no válido.");
            var list = await repository.ListAsync((byte)enumRol);
            var collection = mapper.Map<ICollection<ReservaDTO>>(list);

            return collection;
        }

    }
}