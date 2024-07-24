using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using ArtInk.Utils;
using AutoMapper;
using FluentValidation;
using App = ArtInk.Application.DTOs.Enums;
using Infra = ArtInk.Infraestructure.Enums;

namespace ArtInk.Application.Services.Implementations;

public class ServiceReserva(IRepositoryReserva repository, IMapper mapper,
                            IValidator<Reserva> reservaValidator, IRepositorySucursalHorario repositorySucursalHorario) : IServiceReserva
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

    public async Task<ICollection<ReservaDto>> ReservaDiaBySucursalAsync(byte idSucursal, DateOnly dia)
    {
        var list = await repository.ReservaDiaBySucursalAsync(idSucursal, dia);
        var collection = mapper.Map<ICollection<ReservaDto>>(list);

        return collection;
    }

    public async Task<ICollection<TimeOnly>> DisponibilidadHoraria(byte idSucursal, DateOnly dia)
    {
        var nombreDiaSemana = ManejoFechaHora.ObtenerDiaSemanaCRCulture(dia);
        App.DiaSemana diaSemana = (App.DiaSemana)Enum.Parse(typeof(App.DiaSemana), nombreDiaSemana);

        var horarioSucursal = await repositorySucursalHorario.GetHorarioBySucursalByDiaAsync(idSucursal, mapper.Map<Infra.DiaSemana>(diaSemana));
        if (horarioSucursal == null) throw new NotFoundException("No se encontro horario en la sucursal.");

        var rangoHorario = ManejoFechaHora.ObtenerHoras(horarioSucursal.IdHorarioNavigation.HoraInicio, horarioSucursal.IdHorarioNavigation.HoraFin.AddHours(-1));

        foreach (var item in horarioSucursal.SucursalHorarioBloqueos)
        {
            var rangoHorarioBloqueo = ManejoFechaHora.ObtenerHoras(item.HoraInicio, item.HoraFin.AddHours(-1));
            rangoHorario = rangoHorario.Except(rangoHorarioBloqueo).ToList();
        }

        var reservas = await ReservaDiaBySucursalAsync(idSucursal, dia);

        rangoHorario = rangoHorario.Except(reservas.Select(a => a.Hora)).ToList();

        return rangoHorario;
    }
}

