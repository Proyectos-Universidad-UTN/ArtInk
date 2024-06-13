using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
}
