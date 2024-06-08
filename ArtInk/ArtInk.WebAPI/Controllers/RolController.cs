using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController(IServiceRol serviceRol) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await serviceRol.ListAsync();
            return StatusCode(StatusCodes.Status200OK, users);
        }
    }
}
