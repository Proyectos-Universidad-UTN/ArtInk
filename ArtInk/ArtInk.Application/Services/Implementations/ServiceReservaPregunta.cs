using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceReservaPregunta(IRepositoryReservaPregunta repository, IMapper mapper) : IServiceReservaPregunta
{
    public async Task<ReservaPreguntaDto> FindByIdAsync(int id)
    {
        var reserva = await repository.FindByIdAsync(id);
        if (reserva == null) throw new NotFoundException("Pregunta no encontrada.");

        return mapper.Map<ReservaPreguntaDto>(reserva);
    }

    public async Task<ICollection<ReservaPreguntaDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<ReservaPreguntaDto>>(list);

        return collection;
    }
}