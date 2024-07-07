using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservaController(IServiceReserva serviceReserva) : ControllerBase
{
    [HttpGet("~/api/Rol/{rol}/[controller]")]
    public async Task<IActionResult> GetAllReservasAsync(string rol)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(rol);
        var reservas = await serviceReserva.ListAsync(rol);
        return StatusCode(StatusCodes.Status200OK, reservas);
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAllReservasByRolAsync([FromQuery]string rol)
    //{
    //    ArgumentNullException.ThrowIfNullOrEmpty(rol);
    //    var reservas = await serviceReserva.ListAsync(rol);
    //    return StatusCode(StatusCodes.Status200OK, reservas);
    //}

    [HttpGet("{idReserva}")]
    public async Task<IActionResult> GetReservaByIdAsync(int idReserva)
    {
        var reserva = await serviceReserva.FindByIdAsync(idReserva);
        return StatusCode(StatusCodes.Status200OK, reserva);
    }
}