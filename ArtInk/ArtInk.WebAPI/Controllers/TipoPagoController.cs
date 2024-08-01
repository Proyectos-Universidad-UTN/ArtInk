using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoPagoController(IServiceTipoPago serviceTipoPago) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<TipoPagoDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetTiposPago()
    {
        var coleccion = await serviceTipoPago.ListAllAsync();
        return Ok(coleccion);
    }
}