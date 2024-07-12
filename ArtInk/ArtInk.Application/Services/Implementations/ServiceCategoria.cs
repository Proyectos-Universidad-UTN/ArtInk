using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceCategoria(IRepositoryCategoria repository, IMapper mapper) : IServiceCategoria
{
    public async Task<CategoriaDto> FindByIdAsync(byte id)
    {
        var categoria = await repository.FindByIdAsync(id);
        if (categoria == null) throw new NotFoundException("Categoría no encontrada.");

        return mapper.Map<CategoriaDto>(categoria);
    }

    public async Task<ICollection<CategoriaDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<CategoriaDto>>(list);

        return collection;
    }
}