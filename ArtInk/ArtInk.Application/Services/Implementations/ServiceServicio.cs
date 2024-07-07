using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceServicio(IRepositoryServicio repository, IMapper mapper) : IServiceServicio
{
    public async Task<ServicioDTO> CreateServicioAsync(RequestServicioDTO servicio)
    {
        var result = await repository.CreateServicioAsync(mapper.Map<Servicio>(servicio));
        if (result == null) throw new NotFoundException("Servicio no creado.");
        return mapper.Map<ServicioDTO>(result);
    }

    public async Task<ServicioDTO> FindByIdAsync(byte id)
    {
        var servicio = await repository.FindByIdAsync(id);
        if (servicio == null) throw new NotFoundException("Servicio no encontrado.");

        return mapper.Map<ServicioDTO>(servicio);
    }

    public async Task<ICollection<ServicioDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<ServicioDTO>>(list);

        return collection;
    }
}