using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.WebAPI.Configuration;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;
[ApiController]
[ArtInkAuthorize]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Authorize(Policy = "ArtInk")]
public class SucursalHorarioController(IServiceSucursalHorario serviceSucursalHorario) : ControllerBase
{
    [HttpGet("{idSucursalHorario}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalHorarioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetSucursalByIdAsync(short idSucursalHorario)
    {
        var sucursal = await serviceSucursalHorario.GetSucursalHorarioByIdAsync(idSucursalHorario);
        return StatusCode(StatusCodes.Status200OK, sucursal);
    }

    [HttpGet("~/api/Sucursal/{idSucursal}/Horario")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalHorarioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetHorarioBySucursalAsync(byte idSucursal)
    {
        var sucursal = await serviceSucursalHorario.GetHorariosBySucursalAsync(idSucursal);
        return StatusCode(StatusCodes.Status200OK, sucursal);
    }

    [HttpPost("~/api/Sucursal/{idSucursal}/Horario")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateSucursalHorarioAsync(byte idSucursal, [FromBody] IEnumerable<RequestSucursalHorarioDto> sucursalHorarios)
    {
        ArgumentNullException.ThrowIfNull(sucursalHorarios);
        var result = await serviceSucursalHorario.CreateSucursalHorarioAsync(idSucursal, sucursalHorarios);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}