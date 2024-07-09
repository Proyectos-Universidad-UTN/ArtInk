using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceReservaPregunta(IRepositoryReservaPregunta repository, IMapper mapper) : IServiceReservaPregunta
{
    public async Task<ReservaPreguntaDTO> FindByIdAsync(int id)
    {
        var reserva = await repository.FindByIdAsync(id);
        if (reserva == null) throw new NotFoundException("Pregunta no encontrada.");

        return mapper.Map<ReservaPreguntaDTO>(reserva);
    }

    public async Task<ICollection<ReservaPreguntaDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<ReservaPreguntaDTO>>(list);

        return collection;
    }
}
