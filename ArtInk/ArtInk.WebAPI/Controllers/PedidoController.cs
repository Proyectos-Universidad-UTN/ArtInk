using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
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