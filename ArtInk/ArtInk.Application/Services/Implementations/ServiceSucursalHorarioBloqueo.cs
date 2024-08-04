using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceSucursalHorarioBloqueo(IRepositorySucursalHorarioBloqueo repository,
                                                 IValidator<SucursalHorarioBloqueo> bloqueoValidator, IMapper mapper) : IServiceSucursalHorarioBloqueo
{
    public async Task<SucursalHorarioBloqueoDto> CreateSucursalHorarioBloqueoAsync(RequestSucursalHorarioBloqueoDto bloqueoDTO)
    {
        var bloqueo = await ValidarSucursalHorarioBloqueo(bloqueoDTO);

        var result = await repository.CreateSucursalHorarioBloqueolAsync(bloqueo);
        if (result == null) throw new NotFoundException("Horario bloqueo no se ha creado.");

        return mapper.Map<SucursalHorarioBloqueoDto>(result);
    }

    public async Task<bool> CreateSucursalHorarioBloqueoAsync(short idSucursalHorario, IEnumerable<RequestSucursalHorarioBloqueoDto> bloqueos)
    {
        var bloqueosGuardar = await ValidarSucursalHorarioBloqueo(idSucursalHorario, bloqueos);

        var result = await repository.CreateSucursalHorarioBloqueolAsync(idSucursalHorario, bloqueosGuardar);
        if (!result) throw new ListNotAddedException("Error al guardar bloqueos");

        return result;
    }

    public async Task<SucursalHorarioBloqueoDto> GetSucursalHorarioBloqueosByIdAsync(long id)
    {
        var bloqueo = await repository.FindByIdAsync(id);
        if (bloqueo == null) throw new NotFoundException("Horario bloqueo no encontrado.");

        return mapper.Map<SucursalHorarioBloqueoDto>(bloqueo);
    }

    public async Task<ICollection<SucursalHorarioBloqueoDto>> GetSucursalHorarioBloqueosBySucursalHorarioAsync(short idSucursalHorario)
    {
        var bloqueos = await repository.GetSucursalHorarioBloqueosBySucursalHorarioAsync(idSucursalHorario);

        return mapper.Map<ICollection<SucursalHorarioBloqueoDto>>(bloqueos);
    }

    public async Task<SucursalHorarioBloqueoDto> UpdateSucursalHorarioBloqueoAsync(long id, RequestSucursalHorarioBloqueoDto bloqueoDTO)
    {
        if (!await repository.ExisteHorarioBloqueo(id)) throw new NotFoundException("Horario bloqueo no encontrada.");

        var bloqueo = await ValidarSucursalHorarioBloqueo(bloqueoDTO);
        bloqueo.Id = id;
        var result = await repository.UpdateSucursalHorarioBloqueolAsync(bloqueo);

        return mapper.Map<SucursalHorarioBloqueoDto>(result);
    }

    private async Task<SucursalHorarioBloqueo> ValidarSucursalHorarioBloqueo(RequestSucursalHorarioBloqueoDto bloqueolDTO)
    {
        var bloqueo = mapper.Map<SucursalHorarioBloqueo>(bloqueolDTO);
        await bloqueoValidator.ValidateAndThrowAsync(bloqueo);
        return bloqueo;
    }

    private async Task<IEnumerable<SucursalHorarioBloqueo>> ValidarSucursalHorarioBloqueo(short idSucursalHorario, IEnumerable<RequestSucursalHorarioBloqueoDto> bloqueoDtos)
    {
        var bloqueos = mapper.Map<List<SucursalHorarioBloqueo>>(bloqueoDtos);
        foreach (var item in bloqueos)
        {
            item.Id = 0;
            item.IdSucursalHorario = idSucursalHorario;
            await bloqueoValidator.ValidateAndThrowAsync(item);
        }
        return bloqueos;
    }
}