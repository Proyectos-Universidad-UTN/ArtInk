using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces.Authorization;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations.Authorization;

public class ServiceUserAuthorization(IServiceUserContext serviceUserContext, IRepositoryUsuario repositoryUsuario, IMapper mapper) : IServiceUserAuthorization
{
    public async Task<UsuarioDto> GetLoggedUser()
    {
        var usuario = await repositoryUsuario.FindByEmailAsync(serviceUserContext.UserId!);
        var user = usuario ?? throw new NotFoundException("No existe el usuario");
        return mapper.Map<UsuarioDto>(user);
    }
}