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
    public class ServiceUnidadMedida(IRepositoryUnidadMedida repository, IMapper mapper) : IServiceUnidadMedida
    {
        public async Task<UnidadMedidaDTO> FindByIdAsync(byte id)
        {
            var unidad = await repository.FindByIdAsync(id);
            if (unidad == null) throw new Exception("Unidad de medida no encontrada.");

            return mapper.Map<UnidadMedidaDTO>(unidad);
        }

        public async Task<ICollection<UnidadMedidaDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<UnidadMedidaDTO>>(list);

            return collection;
        }
    }
}
