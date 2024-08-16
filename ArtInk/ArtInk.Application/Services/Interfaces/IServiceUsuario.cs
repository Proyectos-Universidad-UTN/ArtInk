using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceUsuario
{
    Task<ICollection<UsuarioDto>> ListAsync(string? rol = null);

    Task<UsuarioDto> FindByIdAsync(short id);

    Task<bool> LibreAsignacionSucursal(short id, byte idSucursalAsignacion);
}