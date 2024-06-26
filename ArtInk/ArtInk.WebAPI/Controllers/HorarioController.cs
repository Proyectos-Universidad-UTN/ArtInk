﻿using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController(IServiceHorario serviceHorario) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHorariosAsync()
        {
            var horarios = await serviceHorario.ListAsync();
            return StatusCode(StatusCodes.Status200OK, horarios);
        }

        [HttpGet("{idHorario}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(HorarioDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
        public async Task<IActionResult> GetHorarioByIdAsync(short idHorario)
        {
            var horario = await serviceHorario.FindByIdAsync(idHorario);
            return StatusCode(StatusCodes.Status200OK, horario);
        }
    }
}
