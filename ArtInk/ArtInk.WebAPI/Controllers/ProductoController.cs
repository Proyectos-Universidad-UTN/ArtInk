using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController(IServiceProducto serviceProducto) : ControllerBase
    {
        [HttpGet]
        public async Task <IActionResult> GetAllProductosAsync()
        {
            var productos= await serviceProducto.ListAsync();
            return StatusCode(StatusCodes.Status200OK, productos);
        }
    }
}
