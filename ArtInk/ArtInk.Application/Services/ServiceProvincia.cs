using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services
{
    public class ServiceProvincia(IRepositoryProvincia repository, IMapper mapper) : IServiceProvincia
    {
        public async Task<ProvinciaDTO> FindByIdAsync(byte id)
        {
            var provincia = await repository.FindByIdAsync(id);
            if (provincia == null) throw new Exception("Provincia no encontrada.");

            return mapper.Map<ProvinciaDTO>(provincia);
        }

        public async Task<ICollection<ProvinciaDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<ProvinciaDTO>>(list);

            return collection;
        }
    }
}
