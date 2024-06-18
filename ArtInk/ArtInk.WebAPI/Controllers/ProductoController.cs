using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
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

        [HttpGet("{idProducto}")]
        public async Task<IActionResult> GetProductoByIdAsync(short idProducto)
        {
            var producto = await serviceProducto.FindByIdAsync(idProducto);
            return StatusCode(StatusCodes.Status200OK, producto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public async Task<IActionResult> CreateProductoAsync([FromBody]RequestProductoDTO producto)
        {
            //retorna una excepçión is es nulo
            ArgumentNullException.ThrowIfNull(producto);
            var result = await serviceProducto.CreateProductoAsync(producto);
            return StatusCode(StatusCodes.Status201Created, producto);
        }
    }
}
