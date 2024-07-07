using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceRol(IRepositoryRol repository, IMapper mapper) : IServiceRol
{
    public async Task<RolDTO> FindByIdAsync(byte id)
    {
        var rol = await repository.FindByIdAsync(id);
        if (rol == null) throw new NotFoundException("Rol no encontrado.");

        return mapper.Map<RolDTO>(rol);
    }

    public async Task<ICollection<RolDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<RolDTO>>(list);

        return collection;
    }
}
