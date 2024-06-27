using ArtInk.Application.Comunes;
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
    public class ServiceHorario(IRepositoryHorario repository, IMapper mapper) : IServiceHorario
    {
        /// <summary>
        /// buscarlo por ID
        /// </summary>
        public async Task<HorarioDTO> FindByIdAsync(short id)
        {
            var horario = await repository.FindByIdAsync(id);
            if (horario == null) throw new NotFoundException("Horario no encontrada.");

            return mapper.Map<HorarioDTO>(horario);
        }

        /// <summary>
        /// buscar toda la lista
        /// </summary>
        /// <returns>ICollection<HorarioDTO></returns>
        public async Task<ICollection<HorarioDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<HorarioDTO>>(list);

            return collection;
        }
    }
}