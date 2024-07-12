using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceReserva(IRepositoryReserva repository, IMapper mapper) : IServiceReserva
{
    public async Task<ReservaDto> FindByIdAsync(int id)
    {
        var reserva = await repository.FindByIdAsync(id);
        if (reserva == null) throw new NotFoundException("Reserva no encontrada.");

        return mapper.Map<ReservaDto>(reserva);
    }

    public async Task<ICollection<ReservaDto>> ListAsync(string rol)
    {
        Rol enumRol;
        if (!Enum.TryParse<Rol>(rol, true, out enumRol)) throw new BadRequestException("Rol no válido.");
        var list = await repository.ListAsync((byte)enumRol);
        var collection = mapper.Map<ICollection<ReservaDto>>(list);

        return collection;
    }
}