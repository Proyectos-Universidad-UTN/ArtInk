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
public class ServicioController(IServiceServicio serviceServicio) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServicioDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllServiciosAsync()
    {
        var servicios = await serviceServicio.ListAsync();
        return StatusCode(StatusCodes.Status200OK, servicios);
    }

    [HttpGet("{idServicio}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServicioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetServicioByIdAsync(byte idServicio)
    {
        var servicio = await serviceServicio.FindByIdAsync(idServicio);
        return StatusCode(StatusCodes.Status200OK, servicio);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ServicioDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateServicioAsync([FromBody] RequestServicioDto servicio)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(servicio);
        var result = await serviceServicio.CreateServicioAsync(servicio);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idServicio}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServicioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateServicioAsync(byte idServicio, [FromBody] RequestServicioDto servicio)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(servicio);
        var result = await serviceServicio.UpdateServicioAsync(idServicio, servicio);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}