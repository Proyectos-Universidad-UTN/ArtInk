using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceUsuario(IRepositoryUsuario repository, IRepositorySucursal repositorySucursal, IMapper mapper) : IServiceUsuario
{
    public async Task<UsuarioDto> FindByIdAsync(short id)
    {
        var usuario = await repository.FindByIdAsync(id);
        if (usuario == null) throw new NotFoundException("Usuario no encontrado.");

        return mapper.Map<UsuarioDto>(usuario);
    }

    public async Task<bool> LibreAsignacionSucursal(short id, byte idSucursalAsignacion)
    {
        var usuario = await repository.ExistsByIdAsync(id);
        if (!usuario) throw new NotFoundException("Usuario no encontrado.");

        var sucursal = await repositorySucursal.ExisteSucursal(idSucursalAsignacion);
        if (!sucursal) throw new NotFoundException("Sucursal no encontrada.");

        return await repository.LibreAsignacionSucursal(id, idSucursalAsignacion);
    }

    public async Task<ICollection<UsuarioDto>> ListAsync(string? rol = null)
    {
        if(rol == null)
        {
            var list = await repository.ListAsync();
            return mapper.Map<ICollection<UsuarioDto>>(list);
        }

        Rol rolEnum;
        if (!Enum.TryParse(rol, out rolEnum)) throw new ArtInkException("Rol Inválido");

        var listFilter = await repository.ListAsync((byte)rolEnum);
        var collection = mapper.Map<ICollection<UsuarioDto>>(listFilter); 

        return collection;
    }
}