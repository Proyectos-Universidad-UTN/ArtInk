using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
using ArtInk.Application.Services.Interfaces;
using ArtInk.WebAPI.Configuration;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Authorize(Policy = "ArtInk")]
[ArtInkAuthorize(Rol.ADMINISTRADOR)]
public class UsuarioController(IServiceUsuario serviceUsuario) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<UsuarioDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = await serviceUsuario.ListAsync();
        return StatusCode(StatusCodes.Status200OK, users);
    }

    [HttpGet("~/api/[controller]/ByRol/{rol}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<UsuarioDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllUsersByRolAsync(string rol)
    {
        var users = await serviceUsuario.ListAsync(rol);
        return StatusCode(StatusCodes.Status200OK, users);
    }

    [HttpGet("~/api/[controller]/{id}/Sucursal/{idSucursal}/libre-asignacion")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> ValidarLibreAsignacionSucursalAsync(short id, byte idSucursal)
    {
        var libre = await serviceUsuario.LibreAsignacionSucursal(id, idSucursal);
        return StatusCode(StatusCodes.Status200OK, libre);
    }
}