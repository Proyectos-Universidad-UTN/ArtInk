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
public class InventarioProductoMovimientoController(IServiceInventarioProductoMovimiento serviceInventarioProductoMovimiento) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(InventarioProductoMovimientoDto))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateInventarioAsync([FromBody] RequestInventarioProductoMovimientoDto inventarioProductoMovimientoDto)
    {
        ArgumentNullException.ThrowIfNull(inventarioProductoMovimientoDto);
        var result = await serviceInventarioProductoMovimiento.AgregarInventarioMovimientoProducto(inventarioProductoMovimientoDto);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpGet("~/api/Inventario/{idInventario}/Movimientos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<InventarioDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllMovimientosInventarioByInventarioAsync(short idInventario)
    {
        var inventarios = await serviceInventarioProductoMovimiento.ObtenerMovimientosInventarioByInventario(idInventario);
        return StatusCode(StatusCodes.Status200OK, inventarios);
    }

    [HttpGet("~/api/Producto/{idProducto}/Movimientos")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<InventarioDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllMovimientosInventarioByProductoAsync(short idProducto)
    {
        var inventarios = await serviceInventarioProductoMovimiento.ObtenerMovimientosInventarioByProducto(idProducto);
        return StatusCode(StatusCodes.Status200OK, inventarios);
    }
}