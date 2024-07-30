using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReservaServicioController(IServiceReservaServicio serviceReservaServicio) : ControllerBase
{
    [HttpGet("{idReservaServicio}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservaServicioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetReservaByIdAsync(int idReservaServicio)
    {
        var reserva = await serviceReservaServicio.GetReservaServicioByIdAsync (idReservaServicio);
        return StatusCode(StatusCodes.Status200OK, reserva);
    }

    [HttpGet("~/api/Reserva/{idReserva}/Servicio")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservaServicioDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetServicioByReservaAsync(int idReserva)
    {
        var sucursal = await serviceReservaServicio.GetServiciosByReservaAsync(idReserva);
        return StatusCode(StatusCodes.Status200OK, sucursal);
    }

    [HttpPost("~/api/Reserva/{idReserva}/Servicio")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateReservaServicioAsync(int idReserva, [FromBody] IEnumerable<RequestReservaServicioDto> reservaServicios)
    {
        ArgumentNullException.ThrowIfNull(reservaServicios);
        var result = await serviceReservaServicio.CreateReservaServicioAsync(idReserva, reservaServicios);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}