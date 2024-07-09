using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Application.Validations;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceHorario(IRepositoryHorario repository, IMapper mapper,
                            IValidator<Horario> horarioValidator) : IServiceHorario
{
    public async Task<HorarioDTO> CreateHorarioAsync(RequestHorarioDTO horarioDTO)
    {
        var horario = await ValidarHorario(horarioDTO);

        var result = await repository.CreateHorarioAsync(horario);
        if (result == null) throw new NotFoundException("Horario no se ha creado.");

        return mapper.Map<HorarioDTO>(result);
    }
    public async Task<HorarioDTO> UpdateHorarioAsync(short id, RequestHorarioDTO horarioDTO)
    {
        if (!await repository.ExisteHorario(id)) throw new NotFoundException("Horario no encontrado.");

        var horario = await ValidarHorario(horarioDTO);
        horario.Id = id;
        var result = await repository.UpdateHorarioAsync(horario);

        return mapper.Map<HorarioDTO>(result);
    }

    public async Task<HorarioDTO> FindByIdAsync(short id)
    {
        var horario = await repository.FindByIdAsync(id);
        if (horario == null) throw new NotFoundException("Horario no encontrada.");

        return mapper.Map<HorarioDTO>(horario);
    }

    public async Task<ICollection<HorarioDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<HorarioDTO>>(list);

        return collection;
    }

    private async Task<Horario> ValidarHorario(RequestHorarioDTO horarioDTO)
    {
        var horario = mapper.Map<Horario>(horarioDTO);
        await horarioValidator.ValidateAndThrowAsync(horario);
        return horario;
    }
}