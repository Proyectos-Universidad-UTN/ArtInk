using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceDistrito(IRepositoryDistrito repository, IMapper mapper) : IServiceDistrito
{
    public async Task<DistritoDTO> FindByIdAsync(byte id)
    {
        var distrito = await repository.FindByIdAsync(id);
        if (distrito == null) throw new NotFoundException("Distrito no encontrado.");

        return mapper.Map<DistritoDTO>(distrito);
    }

    public async Task<ICollection<DistritoDTO>> ListAsync(byte idCanton)
    {
        var list = await repository.ListAsync(idCanton);
        var collection = mapper.Map<ICollection<DistritoDTO>>(list);

        return collection;
    }
}
