using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioSucursalController(IServiceUsuarioSucursal serviceUsuarioSucursal) : ControllerBase
{
    [HttpPost("~/api/Sucursal/{idSucursal}/Usuarios")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateSucursalHorarioAsync(byte idSucursal, [FromBody] IEnumerable<RequestUsuarioSucursalDto> usuarioSucursalDto)
    {
        ArgumentNullException.ThrowIfNull(usuarioSucursalDto);
        var result = await serviceUsuarioSucursal.AsignarEncargados(idSucursal, usuarioSucursalDto);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}