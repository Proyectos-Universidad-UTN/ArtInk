using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeriadoController(IServiceFeriado serviceFeriado) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FeriadoDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllFeriadosAsync()
    {
        var sucursales = await serviceFeriado.ListAsync();
        return StatusCode(StatusCodes.Status200OK, sucursales);
    }

    [HttpGet("{idFeriado}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FeriadoDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetFeriadoByIdAsync(byte idFeriado)
    {
        var feriado = await serviceFeriado.FindByIdAsync(idFeriado);
        return StatusCode(StatusCodes.Status200OK, feriado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FeriadoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateFeriadoAsync([FromBody] RequestFeriadoDto feriado)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(feriado);
        var result = await serviceFeriado.CreateFeriadoAsync(feriado);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idFeriado}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FeriadoDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateFeriadoAsync(byte idFeriado, [FromBody] RequestFeriadoDto feriado)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(feriado);
        var result = await serviceFeriado.UpdateFeriadoAsync(idFeriado, feriado);
        return StatusCode(StatusCodes.Status200OK, result);
    }

    [HttpDelete("{idFeriado}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FeriadoDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> DeleteFeriado(byte idFeriado)
    {
        var result = await serviceFeriado.DeleteFeriadoAsync(idFeriado);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}