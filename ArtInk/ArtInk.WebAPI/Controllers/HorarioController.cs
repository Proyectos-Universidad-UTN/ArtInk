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
public class HorarioController(IServiceHorario serviceHorario) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<HorarioDto>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllHorariosAsync()
    {
        var horarios = await serviceHorario.ListAsync();
        return StatusCode(StatusCodes.Status200OK, horarios);
    }

    [HttpGet("{idHorario}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HorarioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetHorarioByIdAsync(short idHorario)
    {
        var horario = await serviceHorario.FindByIdAsync(idHorario);
        return StatusCode(StatusCodes.Status200OK, horario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HorarioDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateHorarioAsync([FromBody] RequestHorarioDto horario)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(horario);
        var result = await serviceHorario.CreateHorarioAsync(horario);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idHorario}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HorarioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateHorarioAsync(short idHorario, [FromBody] RequestHorarioDto horario)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(horario);
        var result = await serviceHorario.UpdateHorarioAsync(idHorario, horario);
        return StatusCode(StatusCodes.Status200OK, result);
    }

}