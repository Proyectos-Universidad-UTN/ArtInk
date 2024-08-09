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
[Route("api/Sucursal/{idSucursal}/[controller]")]
[Authorize(Policy = "ArtInk")]
public class InventarioController(IServiceInventario serviceInventario) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<InventarioDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllInventariosAsync(byte idSucursal)
    {
        var inventarios = await serviceInventario.ListAsync(idSucursal);
        return StatusCode(StatusCodes.Status200OK, inventarios);
    }

    [HttpGet("~/api/[controller]/{idInventario}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InventarioDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetInventarioByIdAsync(short idInventario)
    {
        var inventario = await serviceInventario.FindByIdAsync(idInventario);
        return StatusCode(StatusCodes.Status200OK, inventario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InventarioDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateInventarioAsync(byte idSucursal, [FromBody] RequestInventarioDto inventario)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(inventario);
        var result = await serviceInventario.CreateInventarioAsync(idSucursal, inventario);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idInventario}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventarioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateInvetarioAsync(byte idSucursal, short idInventario, [FromBody] RequestInventarioDto inventario)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(inventario);
        var result = await serviceInventario.UpdateInventarioAsync(idSucursal, idInventario, inventario);
        return StatusCode(StatusCodes.Status200OK, result);
    }

    [HttpDelete("~/api/[controller]/{idInventario}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> DeleteFeriado(short idInventario)
    {
        var result = await serviceInventario.DeleteInventarioAsync(idInventario);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}