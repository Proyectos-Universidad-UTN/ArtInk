﻿using ArtInk.Application.DTOs;
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
public class SucursalHorarioBloqueoController(IServiceSucursalHorarioBloqueo serviceBloqueo) : ControllerBase
{
    

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SucursalHorarioBloqueoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateSucursalHorarioBloqueoAsync([FromBody] RequestSucursalHorarioBloqueoDto bloqueo)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(bloqueo);
        var result = await serviceBloqueo.CreateSucursalHorarioBloqueoAsync(bloqueo);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPost("~/api/SucursalHorario/{idSucursalHorario}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SucursalHorarioBloqueoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateSucursalHorarioBloqueoAsync(short idSucursalHorario, [FromBody] IEnumerable<RequestSucursalHorarioBloqueoDto> bloqueos)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(bloqueos);
        var result = await serviceBloqueo.CreateSucursalHorarioBloqueoAsync(idSucursalHorario, bloqueos);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idSucursalHorarioBloqueo}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalHorarioBloqueoDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateSucursalHorarioBloqueoAsync(long idSucursalHorarioBloqueo, [FromBody] RequestSucursalHorarioBloqueoDto bloqueo)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(bloqueo);
        var result = await serviceBloqueo.UpdateSucursalHorarioBloqueoAsync(idSucursalHorarioBloqueo, bloqueo);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}