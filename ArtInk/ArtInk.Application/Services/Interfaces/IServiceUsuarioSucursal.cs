using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceUsuarioSucursal
{
    Task<bool> AsignarEncargados(byte idSucursal, IEnumerable<RequestUsuarioSucursalDto> usuariosSucursalDto);
}