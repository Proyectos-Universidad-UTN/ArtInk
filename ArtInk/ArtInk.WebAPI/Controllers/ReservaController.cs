using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController(IServiceReserva serviceReserva) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllReservasAsync()
        {
            var reservas = await serviceReserva.ListAsync();
            return StatusCode(StatusCodes.Status200OK, reservas);
        }

        [HttpGet("{idReserva}")]
        public async Task<IActionResult> GetReservaByIdAsync(int idReserva)
        {
            var reserva = await serviceReserva.FindByIdAsync(idReserva);
            return StatusCode(StatusCodes.Status200OK, reserva);
        }
    }
}
