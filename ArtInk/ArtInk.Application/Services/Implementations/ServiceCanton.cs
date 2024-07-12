using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceCanton(IRepositoryCanton repository, IMapper mapper) : IServiceCanton
{
    public async Task<CantonDto> FindByIdAsync(byte id)
    {
        var canton = await repository.FindByIdAsync(id);
        if (canton == null) throw new NotFoundException("Cantón no encontrado.");

        return mapper.Map<CantonDto>(canton);
    }

    public async Task<ICollection<CantonDto>> ListAsync(byte idProvincia)
    {
        var list = await repository.ListAsync(idProvincia);
        var collection = mapper.Map<ICollection<CantonDto>>(list);

        return collection;
    }
}