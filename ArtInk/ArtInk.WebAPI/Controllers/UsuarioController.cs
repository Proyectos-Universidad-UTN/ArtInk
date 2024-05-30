using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IServiceUsuario serviceUsuario) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users= await serviceUsuario.ListAsync();
            return StatusCode(StatusCodes.Status200OK, users);
        }
    }
}
