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
    public class ServiceSucursal(IRepositorySucursal repository, IMapper mapper) : IServiceSucursal
    {
        public async Task<SucursalDTO> FindByIdAsync(byte id)
        {
            var sucursal = await repository.FindByIdAsync(id);
            if (sucursal == null) throw new Exception("Sucursal no encontrada.");

            return mapper.Map<SucursalDTO>(sucursal);
        }
        public async Task<ICollection<SucursalDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<SucursalDTO>>(list);

            return collection;
        }
    }
}
