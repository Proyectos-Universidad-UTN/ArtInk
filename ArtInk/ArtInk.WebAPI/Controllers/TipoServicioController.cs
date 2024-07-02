using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoServicioController(IServiceTipoServicio serviceTipoServicio) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTipoServiciosAsync()
        {
            var users = await serviceTipoServicio.ListAsync();
            return StatusCode(StatusCodes.Status200OK, users);
        }
    }
}
