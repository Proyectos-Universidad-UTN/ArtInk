using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceCategoria(IRepositoryCategoria repository, IMapper mapper) : IServiceCategoria
{
    public async Task<CategoriaDTO> FindByIdAsync(byte id)
    {
        var categoria = await repository.FindByIdAsync(id);
        if (categoria == null) throw new NotFoundException("Categoría no encontrada.");

        return mapper.Map<CategoriaDTO>(categoria);
    }

    public async Task<ICollection<CategoriaDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<CategoriaDTO>>(list);

        return collection;
    }
}
