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
    public class ServiceServicio(IRepositoryServicio repository, IMapper mapper,
                                IValidator<Servicio> servicioValidator) : IServiceServicio
    {
        public async Task<ServicioDto> CreateServicioAsync(RequestServicioDto servicio)
        {
            var result = await repository.CreateServicioAsync(mapper.Map<Servicio>(servicio));
            if (result == null) throw new NotFoundException("Servicio no creado.");
            return mapper.Map<ServicioDto>(result);
        }

        public async Task<ServicioDto> FindByIdAsync(byte id)
        {
            var servicio = await repository.FindByIdAsync(id);
            if (servicio == null) throw new NotFoundException("Servicio no encontrado.");

            return mapper.Map<ServicioDto>(servicio);
        }

        public async Task<ICollection<ServicioDto>> ListAsync()
        {
            var list = await repository.ListAsync();
            var collection = mapper.Map<ICollection<ServicioDto>>(list);

            return collection;
        }

        public async Task<ServicioDto> UpdateServicioAsync(byte id, RequestServicioDto servicioDTO)
        {
            if (!await repository.ExisteServicio(id)) throw new NotFoundException("Servicio no encontrado.");

            var sucursal = await ValidarServicio(servicioDTO);
            sucursal.Id = id;
            var result = await repository.UpdateServicioAsync(sucursal);

            return mapper.Map<ServicioDto>(result);
        }

        private async Task<Servicio> ValidarServicio(RequestServicioDto servicioDTO)
        {
            var servicio = mapper.Map<Servicio>(servicioDTO);
            await servicioValidator.ValidateAndThrowAsync(servicio);
            return servicio;
        }
    }
}