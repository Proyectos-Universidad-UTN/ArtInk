using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceRol(IRepositoryRol repository, IMapper mapper) : IServiceRol
{
    public async Task<RolDto> FindByIdAsync(byte id)
    {
        var rol = await repository.FindByIdAsync(id);
        if (rol == null) throw new NotFoundException("Rol no encontrado.");

        return mapper.Map<RolDto>(rol);
    }

    public async Task<ICollection<RolDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<RolDto>>(list);

        return collection;
    }
}