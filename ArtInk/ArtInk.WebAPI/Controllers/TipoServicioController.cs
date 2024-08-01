using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoServicioController(IServiceTipoServicio serviceTipoServicio) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<TipoServicioDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllTipoServiciosAsync()
    {
        var users = await serviceTipoServicio.ListAsync();
        return StatusCode(StatusCodes.Status200OK, users);
    }
}