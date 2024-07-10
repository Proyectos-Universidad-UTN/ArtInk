using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SucursalFeriadoController(IServiceSucursalFeriado serviceSucursalFeriado) : ControllerBase
{
    [HttpGet("~/api/Sucursal/{idSucursal}/Feriado")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SucursalFeriadoDTO>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllSucursalesAsync(byte idSucursal, [FromQuery] short? anno)
    {
        short? annoBusqueda = null;
        if (anno != null) annoBusqueda = anno == 0 ? (short)DateTime.Now.Year : anno.Value;
        var sucursalFeriadoDTOs = await serviceSucursalFeriado.GetFeriadosBySucursalAsync(idSucursal, annoBusqueda);
        return StatusCode(StatusCodes.Status200OK, sucursalFeriadoDTOs);
    }

    [HttpGet("{idSucursalFeriado}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalFeriadoDTO))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetSucursalByIdAsync(short idSucursalFeriado)
    {
        var sucursal = await serviceSucursalFeriado.GetSucursalFeriadoByIdAsync(idSucursalFeriado);
        return StatusCode(StatusCodes.Status200OK, sucursal);
    }

    [HttpPost("~/api/Sucursal/{idSucursal}/Feriado")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateSucursalAsync(byte idSucursal, [FromBody] IEnumerable<RequestSucursalFeriadoDTO> sucursalFeriados)
    {
        ArgumentNullException.ThrowIfNull(sucursalFeriados);
        var result = await serviceSucursalFeriado.CreateSucursalFeriadosAsync(idSucursal, sucursalFeriados);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}