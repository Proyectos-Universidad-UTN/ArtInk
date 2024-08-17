using System.Globalization;
using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Enums;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using ArtInk.Utils;
using AutoMapper;
using FluentValidation;
using Microsoft.Identity.Client;
using App = ArtInk.Application.DTOs.Enums;
using Infra = ArtInk.Infraestructure.Enums;

namespace ArtInk.Application.Services.Implementations;

public class ServiceReserva(IRepositoryReserva repository, IRepositorySucursalHorarioBloqueo repositorySucursalHorarioBloqueo, 
                            IRepositorySucursalFeriado repositorySucursalFeriado, IMapper mapper,
                            IValidator<Reserva> reservaValidator, IRepositorySucursalHorario repositorySucursalHorario) : IServiceReserva
{
    const string formatoFecha = "yyyy-MM-dd";

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

    public async Task<ICollection<AgendaCalendarioReserva>> ListAsync(byte idSucursal, DateOnly? fechaInicio, DateOnly? fechaFin)
    {
        var list = fechaInicio == null || fechaFin == null ? await repository.ListAsync(idSucursal) : await repository.ListAsync(idSucursal, fechaInicio.Value, fechaFin.Value);
        
        var agendaCalendario = (from a in list
                               select new AgendaCalendarioReserva
                               {
                                Title = $"{a.Id}-{a.NombreCliente}",
                                Start = new DateTime(a.Fecha.Year, a.Fecha.Month, a.Fecha.Day, a.Hora.Hour, a.Hora.Minute, a.Hora.Second, DateTimeKind.Unspecified),
                                End = new DateTime(a.Fecha.Year, a.Fecha.Month, a.Fecha.Day, a.Hora.Hour + 1, a.Hora.Minute, a.Hora.Second, DateTimeKind.Unspecified)
                               }).ToList();

        if(fechaInicio != null && fechaFin != null)
        {
            var agendaBloqueos = await ObtenerBloqueosAsync(idSucursal, fechaInicio.Value, fechaFin.Value);
            var feriados = await ObtenerFeriados(idSucursal, fechaInicio.Value, fechaFin.Value);

            if(feriados.Any()) agendaBloqueos = agendaBloqueos.Except(agendaBloqueos.Where(m => feriados.Exists(z => z.Start.ToString(formatoFecha) == m.Start.ToString(formatoFecha))).ToList()).ToList();

            agendaCalendario.AddRange(agendaBloqueos);
            agendaCalendario.AddRange(feriados);
        }

        return agendaCalendario;
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

    private async Task<List<AgendaCalendarioReserva>> ObtenerBloqueosAsync(byte idSucursal, DateOnly fechaInicio, DateOnly fechaFin)
    {
        var bloqueos = await repositorySucursalHorarioBloqueo.GetSucursalHorarioBloqueosBySucursalAsync(idSucursal);
        var diferenciaDias = ManejoFechaHora.ObtenerDias(fechaInicio, fechaFin);
        var agendaBloqueos = from a in bloqueos
                                  from b in diferenciaDias
                                  where b.ToString("dddd", new CultureInfo("es-CR")).Capitalize().Replace("é", "e").Replace("á", "a") == Enum.GetName(typeof(DiaSemana), a.IdSucursalHorarioNavigation.IdHorarioNavigation.Dia)! 
                                  select new AgendaCalendarioReserva
                                    {
                                        Title = "",
                                        Start = new DateTime(b.Year, b.Month, b.Day, a.HoraInicio.Hour, a.HoraInicio.Minute, a.HoraInicio.Second, DateTimeKind.Unspecified),
                                        End = new DateTime(b.Year, b.Month, b.Day, a.HoraFin.Hour, a.HoraFin.Minute, a.HoraFin.Second, DateTimeKind.Unspecified),
                                        Display = "background",
                                        ClassNames = "bg-danger"
                                    };
        return agendaBloqueos.ToList();
    }

    private async Task<List<AgendaCalendarioReserva>> ObtenerFeriados(byte idSucursal, DateOnly fechaInicio, DateOnly fechaFin)
    {
        var feriados = await repositorySucursalFeriado.GetFeriadosBySucursalAsync(idSucursal, fechaInicio, fechaFin);
        var agendaFeriados = from a in feriados 
                                  select new AgendaCalendarioReserva
                                    {
                                        Title = $"Feriado: {a.IdFeriadoNavigation.Nombre}",
                                        Start = DateTime.ParseExact(a.Fecha.ToString(formatoFecha), formatoFecha, CultureInfo.InvariantCulture),
                                        Display = "background",
                                        ClassNames = "bg-warning",
                                        AllDay = true,
                                    };

        return agendaFeriados.ToList();
    }
}

