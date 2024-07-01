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
    public class ServiceTipoServicio(IRepositoryTipoServicio repository, IMapper mapper) : IServiceTipoServicio
    {
        public async Task<TipoServicioDTO> FindByIdAsync(byte id)
        {
            var tipoServicio = await repository.FindByIdAsync(id);
            if (tipoServicio == null) throw new Exception("Tipo de servicio no encontrado.");

            return mapper.Map<TipoServicioDTO>(tipoServicio);
        }

        public async Task<ICollection<TipoServicioDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<TipoServicioDTO>>(list);

            return collection;
        }
    }
}
