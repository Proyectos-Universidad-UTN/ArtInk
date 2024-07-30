using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Application.Validations;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtInk.Application.Services.Implementations
{
    public class ServiceReservaServicio(IRepositoryReservaServicio repository, IMapper mapper,
                                    IValidator<ReservaServicio> reservaServicioValidator) : IServiceReservaServicio
    {
        public async Task<bool> CreateReservaServicioAsync(int idReserva, IEnumerable<RequestReservaServicioDto> reservaServicios)
        {
            var servicios = await ValidateServicios(idReserva, reservaServicios);

            var result = await repository.CreateReservaServicioAsync(idReserva, servicios);
            if (!result) throw new ListNotAddedException("Error al guardar servicios.");

            return result;
        }

        public async Task<ReservaServicioDto?> GetReservaServicioByIdAsync(int id)
        {
            var reservaServicio = await repository.GetServiciosByReservaAsync(id);
            if (reservaServicio == null) throw new NotFoundException("Servicio en la reserva no encontrado.");

            return mapper.Map<ReservaServicioDto>(reservaServicio);
        }

        public async Task<ICollection<ReservaServicioDto>> GetServiciosByReservaAsync(int idReserva)
        {
            var list = await repository.GetServiciosByReservaAsync(idReserva);
            var collection = mapper.Map<ICollection<ReservaServicioDto>>(list);

            return collection;
        }

        private async Task<IEnumerable<ReservaServicio>> ValidateServicios(int idReserva, IEnumerable<RequestReservaServicioDto> reservaServicios)
        {
            var serviciosExistentes = mapper.Map<List<ReservaServicio>>(reservaServicios);
            foreach (var item in serviciosExistentes)
            {
                item.IdReserva = idReserva;
                await reservaServicioValidator.ValidateAndThrowAsync(item);
            }
            return serviciosExistentes;
        }
    }
}
