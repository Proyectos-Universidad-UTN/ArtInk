using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController(IServiceDistrito serviceDistrito) : ControllerBase
    {
        [HttpGet("~/api/Canton/{idCanton}/Distrito")]
        public async Task<IActionResult> GetAllDistritosByCantonAsync(byte idCanton)
        {
            var users = await serviceDistrito.ListAsync(idCanton);
            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistritoAsync(byte id)
        {
            var users = await serviceDistrito.FindByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, users);
        }
    }
}
