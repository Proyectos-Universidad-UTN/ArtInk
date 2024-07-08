using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SucursalController(IServiceSucursal serviceSucursal) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SucursalDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllSucursalesAsync()
    {
        var sucursales = await serviceSucursal.ListAsync();
        return StatusCode(StatusCodes.Status200OK, sucursales);
    }

    [HttpGet("{idSucursal}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetSucursalByIdAsync(byte idSucursal)
    {
        var sucursal = await serviceSucursal.FindByIdAsync(idSucursal);
        return StatusCode(StatusCodes.Status200OK, sucursal);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SucursalDTO))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateSucursalAsync([FromBody] RequestSucursalDTO sucursal)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(sucursal);
        var result = await serviceSucursal.CreateSucursalAsync(sucursal);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idSucursal}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateSucursalAsync(byte idSucursal, [FromBody] RequestSucursalDTO sucursal)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(sucursal);
        var result = await serviceSucursal.UpdateSucursalAsync(idSucursal, sucursal);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}