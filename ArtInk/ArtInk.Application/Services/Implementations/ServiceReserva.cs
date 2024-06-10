using ArtInk.Application.DTOs;
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
    public class ServiceReserva (IRepositoryReserva repository, IMapper mapper) : IServiceReserva
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
        /// buscar toda la lista
        /// </summary>
        /// <returns>ICollection<ProductoDTO></returns>
        public async Task<ICollection<ReservaDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<ReservaDTO>>(list);

            return collection;
        }

    }
}
