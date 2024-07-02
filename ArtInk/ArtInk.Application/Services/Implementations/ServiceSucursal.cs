using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations
{
    public class ServiceSucursal(IRepositorySucursal repository, IMapper mapper, 
                                IValidator<Sucursal> sucursalValidator) : IServiceSucursal
    {
        public async Task<SucursalDTO> CreateSucursalAsync(RequestSucursalDTO sucursalDTO)
        {
            var sucursal = await ValidarSucursal(sucursalDTO);

            var result = await repository.CreateSucursalAsync(sucursal);
            if (result == null) throw new NotFoundException("Sucursal no se ha creado.");

            return mapper.Map<SucursalDTO>(result);
        }

        public async Task<SucursalDTO> UpdateSucursalAsync(byte id, RequestSucursalDTO sucursalDTO)
        {
            if(!await repository.ExisteSucursal(id)) throw new NotFoundException("Sucursal no encontrada.");
            
            var sucursal = await ValidarSucursal(sucursalDTO);
            sucursal.Id = id;
            var result = await repository.UpdateSucursalAsync(sucursal);

            return mapper.Map<SucursalDTO>(result);
        }

        public async Task<SucursalDTO> FindByIdAsync(byte id)
        {
            var sucursal = await repository.FindByIdAsync(id);
            if (sucursal == null) throw new NotFoundException("Sucursal no encontrada.");

            return mapper.Map<SucursalDTO>(sucursal);
        }

        /// <summary>
        /// buscar toda la lista
        /// </summary>
        /// <returns>ICollection<ProductoDTO></returns>
        public async Task<ICollection<SucursalDTO>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<SucursalDTO>>(list);

            return collection;
        }

        private async Task<Sucursal> ValidarSucursal(RequestSucursalDTO sucursalDTO)
        {
            var sucursal = mapper.Map<Sucursal>(sucursalDTO);
            await sucursalValidator.ValidateAndThrowAsync(sucursal);
            return sucursal;
        }
    }
}
