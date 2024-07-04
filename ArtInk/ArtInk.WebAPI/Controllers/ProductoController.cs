using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductoDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public async Task <IActionResult> GetAllProductosAsync()
        {
            var productos= await serviceProducto.ListAsync();
            return StatusCode(StatusCodes.Status200OK, productos);
        }

        [HttpGet("{idProducto}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public async Task<IActionResult> GetProductoByIdAsync(short idProducto)
        {
            var producto = await serviceProducto.FindByIdAsync(idProducto);
            return StatusCode(StatusCodes.Status200OK, producto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public async Task<IActionResult> CreateProductoAsync([FromBody]RequestProductoDTO producto)
        {
            //retorna una excepçión is es nulo
            ArgumentNullException.ThrowIfNull(producto);
            var result = await serviceProducto.CreateProductoAsync(producto);
            return StatusCode(StatusCodes.Status201Created, producto);
        }

        [HttpPut("{idProducto}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
        public async Task<IActionResult> UpdateProductoAsync(short idProducto, [FromBody] RequestProductoDTO producto)
        {
            //retorna una excepçión is es nulo
            ArgumentNullException.ThrowIfNull(producto);
            var result = await serviceProducto.UpdateProductoAsync(idProducto, producto);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
