using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
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
public class ProductoController(IServiceProducto serviceProducto) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProductoDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllProductosAsync([FromQuery]bool excludeProductosInventario = false, [FromQuery]short idInventario = 0)
    {
        var productos = await serviceProducto.ListAsync(excludeProductosInventario, idInventario);
        return StatusCode(StatusCodes.Status200OK, productos);
    }

    [HttpGet("{idProducto}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetProductoByIdAsync(short idProducto)
    {
        var producto = await serviceProducto.FindByIdAsync(idProducto);
        return StatusCode(StatusCodes.Status200OK, producto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProductoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateProductoAsync([FromBody] RequestProductoDto producto)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(producto);
        var result = await serviceProducto.CreateProductoAsync(producto);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idProducto}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductoDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateProductoAsync(short idProducto, [FromBody] RequestProductoDto producto)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(producto);
        var result = await serviceProducto.UpdateProductoAsync(idProducto, producto);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}