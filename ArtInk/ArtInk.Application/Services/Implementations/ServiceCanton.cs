using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations
{
    public class ServiceCanton(IRepositoryCanton repository, IMapper mapper) : IServiceCanton
    {
        public async Task<CantonDTO> FindByIdAsync(byte id)
        {
            var rol = await repository.FindByIdAsync(id);
            if (rol == null) throw new Exception("Cantón no encontrado.");

            return mapper.Map<CantonDTO>(rol);
        }

        public async Task<ICollection<CantonDTO>> ListAsync(byte idProvincia)
        {
            var list = await repository.ListAsync(idProvincia);
            var collection = mapper.Map<ICollection<CantonDTO>>(list);

            return collection;
        }
    }
}