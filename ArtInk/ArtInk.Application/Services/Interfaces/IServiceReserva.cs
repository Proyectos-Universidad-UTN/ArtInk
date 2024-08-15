using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceReserva
{
    Task<ICollection<ReservaDto>> ListAsync();

    Task<ICollection<AgendaCalendarioReserva>> ListAsync(byte idSucursal, DateOnly? fechaInicio, DateOnly? fechaFin);

    Task<ReservaDto> FindByIdAsync(int id);

    Task<ReservaDto> CreateReservaAsync(RequestReservaDto reservaDTO);

    Task<ReservaDto> UpdateReservaAsync(int id, RequestReservaDto reservaDTO);

    Task<ICollection<ReservaDto>> ReservaDiaBySucursalAsync(byte idSucursal, DateOnly dia);

    Task<ICollection<TimeOnly>> DisponibilidadHoraria(byte idSucursal, DateOnly dia);
}