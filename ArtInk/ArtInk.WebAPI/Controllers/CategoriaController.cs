using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController (IServiceCategoria serviceCategoria): ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriasAsync()
        {
            var users = await serviceCategoria.ListAsync();
            return StatusCode(StatusCodes.Status200OK, users);
        }
    }
}
