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
    internal class ServiceSucursalHorarioBloqueo(IRepositorySucursalHorarioBloqueo repository,
                                                 IValidator<SucursalHorarioBloqueo> bloqueoValidator, IMapper mapper) : IServiceSucursalHorarioBloqueo
    {
        public async Task<SucursalHorarioBloqueoDTO> CreateSucursalHorarioBloqueoAsync(RequestSucursalHorarioBloqueoDTO bloqueoDTO)
        {
            var bloqueo = await ValidarSucursalHorarioBloqueo(bloqueoDTO);

            var result = await repository.CreateSucursalHorarioBloqueolAsync (bloqueo);
            if (result == null) throw new NotFoundException("Horario bloqueo no se ha creado.");

            return mapper.Map<SucursalHorarioBloqueoDTO>(result);
        }

        public async Task<SucursalHorarioBloqueoDTO> GetSucursalHorarioBloqueosByIdAsync(long id)
        {
            var bloqueo = await repository.FindByIdAsync(id);
            if (bloqueo == null) throw new NotFoundException("Horario bloqueo no encontrado.");

            return mapper.Map<SucursalHorarioBloqueoDTO>(bloqueo);
        }

        public async Task<ICollection<SucursalHorarioBloqueoDTO>> GetSucursalHorarioBloqueosBySucursalHorarioAsync(short idSucursalHorario)
        {
            var bloqueos = await repository.GetSucursalHorarioBloqueosBySucursalHorarioAsync(idSucursalHorario);
   
            return mapper.Map<ICollection<SucursalHorarioBloqueoDTO>>(bloqueos);
        }

        public async Task<SucursalHorarioBloqueoDTO> UpdateSucursalHorarioBloqueoAsync(long id, RequestSucursalHorarioBloqueoDTO bloqueoDTO)
        {
            if (!await repository.ExisteHorarioBloqueo(id)) throw new NotFoundException("Horario bloqueo no encontrada.");

            var bloqueo = await ValidarSucursalHorarioBloqueo(bloqueoDTO);
            bloqueo.Id = id;
            var result = await repository.UpdateSucursalHorarioBloqueolAsync(bloqueo);

            return mapper.Map<SucursalHorarioBloqueoDTO>(result);
        }

        private async Task<SucursalHorarioBloqueo> ValidarSucursalHorarioBloqueo(RequestSucursalHorarioBloqueoDTO bloqueolDTO)
        {
            var bloqueo = mapper.Map<SucursalHorarioBloqueo>(bloqueolDTO);
            await bloqueoValidator.ValidateAndThrowAsync(bloqueo);
            return bloqueo;
        }
    }
}
