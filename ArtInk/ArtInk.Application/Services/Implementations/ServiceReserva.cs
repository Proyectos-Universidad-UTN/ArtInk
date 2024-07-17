using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Application.Validations;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceReserva(IRepositoryReserva repository, IMapper mapper,
                            IValidator<Reserva> reservaValidator) : IServiceReserva
{
    public async Task<ReservaDto> CreateReservaAsync(RequestReservaDto reservaDTO)
    {
        var reserva = await ValidarReserva(reservaDTO);

        var result = await repository.CreateReservaAsync(reserva);
        if (result == null) throw new NotFoundException("Reserva no se ha creado.");

        return mapper.Map<ReservaDto>(result);
    }

    public async Task<ReservaDto> UpdateReservaAsync(int id, RequestReservaDto reservaDTO)
    {
        if (!await repository.ExisteReserva(id)) throw new NotFoundException("Reserva no encontrada.");

        var reserva = await ValidarReserva(reservaDTO);
        reserva.Id = id;
        var result = await repository.UpdateReservaAsync(reserva);

        return mapper.Map<ReservaDto>(result);
    }

    public async Task<ReservaDto> FindByIdAsync(int id)
    {
        var reserva = await repository.FindByIdAsync(id);
        if (reserva == null) throw new NotFoundException("Reserva no encontrada.");

        return mapper.Map<ReservaDto>(reserva);
    }

    public async Task<ICollection<ReservaDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<ReservaDto>>(list);

        return collection;
    }
    private async Task<Reserva> ValidarReserva(RequestReservaDto reservaDTO)
    {
        var reserva = mapper.Map<Reserva>(reservaDTO);
        await reservaValidator.ValidateAndThrowAsync(reserva);
        return reserva;
    }
}

