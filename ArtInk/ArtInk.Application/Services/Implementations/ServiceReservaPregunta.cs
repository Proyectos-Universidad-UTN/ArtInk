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
    public class ServiceReservaPregunta(IRepositoryReservaPregunta repository, IMapper mapper) : IServiceReservaPregunta
    {
        /// <summary>
        /// buscarlo por ID
        /// </summary>
        public async Task<ReservaPreguntaDTO> FindByIdAsync(int id)
        {
            var reserva = await repository.FindByIdAsync(id);
            if (reserva == null) throw new Exception("Pregunta no encontrada.");

            return mapper.Map<ReservaPreguntaDTO>(reserva);
        }
        /// <summary>
        /// buscar toda la lista
        /// </summary>
        /// <returns>ICollection<ProductoDTO></returns>
        public async Task<ICollection<ReservaPreguntaDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<ReservaPreguntaDTO>>(list);

            return collection;
        }

    }
}
