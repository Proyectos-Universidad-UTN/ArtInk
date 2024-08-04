using ArtInk.Application.Configuration.Pagination;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedorController(IServiceProveedor serviceProveedor) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProveedorDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllServiciosAsync([FromQuery] PaginationParameters? paginationParameters = null)
    {
        if (!paginationParameters!.Paginated) return StatusCode(StatusCodes.Status200OK, await serviceProveedor.ListAsync());

        var paginated = await serviceProveedor.ListAsync(paginationParameters);

        var metadata = new
        {
            paginated.TotalCount,
            paginated.PageSize,
            paginated.CurrentPage,
            paginated.TotalPages,
            paginated.HasNext,
            paginated.HasPrevious
        };

        Response.Headers.Add("X-Pagination", Serialization.Serialize(metadata));
        
        return StatusCode(StatusCodes.Status200OK, paginated);
    }

    [HttpGet("{idProveedor}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProveedorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetProveedorByIdAsync(byte idProveedor)
    {
        var proveedor = await serviceProveedor.FindByIdAsync(idProveedor);
        return StatusCode(StatusCodes.Status200OK, proveedor);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProveedorDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateServicioAsync([FromBody] RequestProveedorDto proveedor)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(proveedor);
        var result = await serviceProveedor.CreateProveedorAsync(proveedor);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idProveedor}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProveedorDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateServicioAsync(byte idProveedor, [FromBody] RequestProveedorDto proveedor)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(proveedor);
        var result = await serviceProveedor.UpdateProveedorsync(idProveedor, proveedor);
        return StatusCode(StatusCodes.Status200OK, result);
    }

    [HttpDelete("{idProveedor}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> DeleteFeriado(byte idProveedor)
    {
        var result = await serviceProveedor.DeleteProveedorsyncAsync(idProveedor);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}