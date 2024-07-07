using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceCanton(IRepositoryCanton repository, IMapper mapper) : IServiceCanton
{
    public async Task<CantonDTO> FindByIdAsync(byte id)
    {
        var canton = await repository.FindByIdAsync(id);
        if (canton == null) throw new NotFoundException("Cantón no encontrado.");

        return mapper.Map<CantonDTO>(canton);
    }

    public async Task<ICollection<CantonDTO>> ListAsync(byte idProvincia)
    {
        var list = await repository.ListAsync(idProvincia);
        var collection = mapper.Map<ICollection<CantonDTO>>(list);

        return collection;
    }
}