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
    public class ServiceServicio(IRepositoryServicio repository, IMapper mapper) : IServiceServicio
    {

        /// <summary>
        /// buscarlo por ID
        /// </summary>
        public async Task<ServicioDTO> FindByIdAsync(byte id)
        {
            var servicio = await repository.FindByIdAsync(id);
            if (servicio == null) throw new Exception("Servicio no encontrado.");

            return mapper.Map<ServicioDTO>(servicio);
        }

        /// <summary>
        /// buscar toda la lista
        /// </summary>
        /// <returns>ICollection<ProductoDTO></returns>
        public async Task<ICollection<ServicioDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<ServicioDTO>>(list);

            return collection;
        }

    }
}
