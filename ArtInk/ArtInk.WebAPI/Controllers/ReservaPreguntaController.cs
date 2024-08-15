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
public class ReservaPreguntaController(IServiceReservaPregunta serviceReservaPregunta) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllReservasPreguntasAsync()
    {
        var reservas = await serviceReservaPregunta.ListAsync();
        return StatusCode(StatusCodes.Status200OK, reservas);
    }

    [HttpGet("{idReservaPregunta}")]
    public async Task<IActionResult> GetReservaPreguntaByIdAsync(int idReservaPregunta)
    {
        var reservaPregunta = await serviceReservaPregunta.FindByIdAsync(idReservaPregunta);
        return StatusCode(StatusCodes.Status200OK, reservaPregunta);
    }
}