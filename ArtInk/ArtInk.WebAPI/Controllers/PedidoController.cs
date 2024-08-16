using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.WebAPI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[ArtInkAuthorize]
[Authorize(Policy = "ArtInk")]
[Route("api/[controller]")]
public class PedidoController(IServicePedido servicePedido) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PedidoDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> Get()
    {
        var inventarios = await servicePedido.ListAsync();
        return StatusCode(StatusCodes.Status200OK, inventarios);
    }

    [HttpGet("{idPedido}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetPedidoByIdAsync(long idPedido)
    {
        var pedido = await servicePedido.FindByIdAsync(idPedido);
        return StatusCode(StatusCodes.Status200OK, pedido);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PedidoDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateProductoAsync([FromBody] RequestPedidoDto pedido)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(pedido);
        var result = await servicePedido.CreatePedidoAsync(pedido);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}