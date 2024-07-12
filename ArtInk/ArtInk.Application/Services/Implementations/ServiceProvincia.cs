using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceProvincia(IRepositoryProvincia repository, IMapper mapper) : IServiceProvincia
{
    public async Task<ProvinciaDto> FindByIdAsync(byte id)
    {
        var provincia = await repository.FindByIdAsync(id);
        if (provincia == null) throw new NotFoundException("Provincia no encontrada.");

        return mapper.Map<ProvinciaDto>(provincia);
    }

    public async Task<ICollection<ProvinciaDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<ProvinciaDto>>(list);

        return collection;
    }
}