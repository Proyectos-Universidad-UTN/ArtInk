using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservaController(IServiceReserva serviceReserva) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReservaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllReservassAsync()
    {
        var reservas = await serviceReserva.ListAsync();
        return StatusCode(StatusCodes.Status200OK, reservas);
    }

    [HttpGet("{idReserva}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservaDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetReservaByIdAsync(int idReserva)
    {
        var reserva = await serviceReserva.FindByIdAsync(idReserva);
        return StatusCode(StatusCodes.Status200OK, reserva);
    }

    [HttpGet("~/api/Sucursal/{idSucursal}/Disponibilidad-Dia/{dia}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<TimeOnly>))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetDisponibilidadHorarioBySucursalByDiaAsync(byte idSucursal, DateTime dia)
    {
        var reserva = await serviceReserva.DisponibilidadHoraria(idSucursal, new DateOnly(dia.Year, dia.Month, dia.Day));
        return StatusCode(StatusCodes.Status200OK, reserva);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ReservaDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateReservaAsync([FromBody] RequestReservaDto reserva)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(reserva);
        var result = await serviceReserva.CreateReservaAsync(reserva);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idReserva}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservaDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateReservaAsync(int idServicio, [FromBody] RequestReservaDto reserva)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(reserva);
        var result = await serviceReserva.UpdateReservaAsync(idServicio, reserva);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}