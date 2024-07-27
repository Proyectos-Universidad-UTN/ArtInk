using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController(IServiceCliente serviceCliente) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClienteDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> Index()
    {
        var clientes = await serviceCliente.ListAllAsync();
        return StatusCode(StatusCodes.Status200OK, clientes);
    }
}