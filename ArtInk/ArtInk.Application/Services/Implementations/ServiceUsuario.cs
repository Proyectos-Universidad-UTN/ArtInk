using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceUsuario(IRepositoryUsuario repository, IMapper mapper) : IServiceUsuario
{
    public async Task<UsuarioDto> FindByIdAsync(short id)
    {
        var usuario = await repository.FindByIdAsync(id);
        if (usuario == null) throw new NotFoundException("Usuario no encontrado.");

        return mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<ICollection<UsuarioDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<UsuarioDto>>(list);

        return collection;
    }
}