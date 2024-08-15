using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.WebAPI.Configuration;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[ArtInkAuthorize]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Authorize(Policy = "ArtInk")]
public class InventarioProductoController(IServiceInventarioProducto serviceInventarioProducto) : ControllerBase
{
    [HttpGet("{idInventarioProducto}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventarioProductoDto))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllInventarioProductosByInventarioAsync(long idInventarioProducto)
    {
        var inventarioProductos = await serviceInventarioProducto.GetInventarioProductoById(idInventarioProducto);
        return StatusCode(StatusCodes.Status200OK, inventarioProductos);
    }

    [HttpGet("~/api/Inventario/{idInventario}/Productos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<InventarioProductoDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllInventarioProductosByInventarioAsync(short idInventario)
    {
        var inventarioProductos = await serviceInventarioProducto.ListByInventarioAsync(idInventario);
        return StatusCode(StatusCodes.Status200OK, inventarioProductos);
    }

    [HttpGet("~/api/Producto/{idProducto}/Inventarios")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<InventarioProductoDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllInventarioProductosByProductoAsync(short idProducto)
    {
        var inventarioProductos = await serviceInventarioProducto.ListByProductoAsync(idProducto);
        return StatusCode(StatusCodes.Status200OK, inventarioProductos);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InventarioProductoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateInventarioProductoAsync([FromBody] RequestInventarioProductoDto inventarioProducto)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(inventarioProducto);
        var result = await serviceInventarioProducto.AgregarProductoInventario(inventarioProducto);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPost("Bulk")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateInventarioProductosAsync([FromBody] IEnumerable<RequestInventarioProductoDto> inventarioProducto)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(inventarioProducto);
        var result = await serviceInventarioProducto.AgregarProductoInventario(inventarioProducto);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idInventarioProducto}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InventarioProductoDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateInvetarioAsync(long idInventarioProducto, [FromBody] RequestInventarioProductoDto inventarioProducto)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(inventarioProducto);
        var result = await serviceInventarioProducto.UpdateProductoInventario(idInventarioProducto, inventarioProducto);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}