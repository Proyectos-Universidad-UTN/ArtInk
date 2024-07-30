using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacturaController(IServiceFactura serviceFactura) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FacturaDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllFacturasAsync()
    {
        var facturas = await serviceFactura.ListAsync();
        return StatusCode(StatusCodes.Status200OK, facturas);
    }

    [HttpGet("{idFactura}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FacturaDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetFacturaByIdAsync(long idFactura)
    {
        var factura = await serviceFactura.FindByIdAsync(idFactura);
        return StatusCode(StatusCodes.Status200OK, factura);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(FacturaDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateFacturaAsync([FromBody] RequestFacturaDto factura)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(factura);
        var result = await serviceFactura.CreateFacturaAsync(factura);
        return StatusCode(StatusCodes.Status201Created, result);
    }
}