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
    public class ServiceSucursalHorario(IRepositorySucursalHorario repository, IMapper mapper,
                                    IValidator<SucursalHorario> sucursalHorarioValidator) : IServiceSucursalHorario
    {
        public async Task<bool> CreateSucursalHorarioAsync(byte idSucursal, IEnumerable<RequestSucursalHorarioDTO> sucursalHorarios)
        {
            var horarios = await ValidateHorarios(idSucursal, sucursalHorarios);

            var result = await repository.CreateSucursalHorariosAsync(idSucursal, horarios);
            if (!result) throw new ListNotAddedExecption("Error al guardar horarios.");

            return result;
        }

        public async Task<ICollection<SucursalHorarioDTO>> GetHorariosBySucursalAsync(byte idSucursal)
        {
            var list = await repository.GetHorariosBySucursalAsync(idSucursal);
            var collection = mapper.Map<ICollection<SucursalHorarioDTO>>(list);

            return collection;
        }

        public async Task<SucursalHorarioDTO?> GetSucursalHorarioByIdAsync(short id)
        {
            var sucursalHorario = await repository.GetSucursalHorarioByIdAsync(id);
            if (sucursalHorario == null) throw new NotFoundException("Horario en sucursal no encontrado.");

            return mapper.Map<SucursalHorarioDTO>(sucursalHorario);
        }

        private async Task<IEnumerable<SucursalHorario>> ValidateHorarios(byte idSucursal, IEnumerable<RequestSucursalHorarioDTO> sucursalHorarios)
        {
            var horariosExistentes = mapper.Map<List<SucursalHorario>>(sucursalHorarios);
            foreach (var item in horariosExistentes)
            {
                item.IdSucursal = idSucursal;
                await sucursalHorarioValidator.ValidateAndThrowAsync(item);
            }
            return horariosExistentes;
        }

    }
}
