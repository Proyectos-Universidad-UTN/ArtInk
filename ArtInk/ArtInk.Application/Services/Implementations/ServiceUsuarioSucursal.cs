using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceUsuarioSucursal(IRepositoryUsuarioSucursal repository, IMapper mapper, IValidator<UsuarioSucursal> usuarioSucursalValidator) : IServiceUsuarioSucursal
{
    public async Task<bool> AsignarEncargados(byte idSucursal, IEnumerable<RequestUsuarioSucursalDto> usuariosSucursalDto)
    {
        var usuariosSucursal = await ValidateUsuariosSucursalAsync(idSucursal, usuariosSucursalDto);
        return await repository.AsignarEncargados(idSucursal, usuariosSucursal);
    }

    private async Task<IEnumerable<UsuarioSucursal>> ValidateUsuariosSucursalAsync(byte idSucursal, IEnumerable<RequestUsuarioSucursalDto> usuariosSucursal)
    {
        var usuariosSucursalExistentes = mapper.Map<List<UsuarioSucursal>>(usuariosSucursal);
        foreach (var item in usuariosSucursalExistentes)
        {
            item.IdSucursal = idSucursal;
            await usuarioSucursalValidator.ValidateAndThrowAsync(item);
        }
        return usuariosSucursalExistentes;
    }
}