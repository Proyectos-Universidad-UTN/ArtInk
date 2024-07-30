using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImpuestoController(IServiceImpuesto serviceImpuesto) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ImpuestoDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetImpuestos()
    {
        var coleccion = await serviceImpuesto.ListAllAsync();
        return Ok(coleccion);
    }
}