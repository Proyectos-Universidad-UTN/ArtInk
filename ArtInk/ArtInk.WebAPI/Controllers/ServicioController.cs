using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicioController(IServiceServicio serviceServicio) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllServiciosAsync()
    {
        var servicios = await serviceServicio.ListAsync();
        return StatusCode(StatusCodes.Status200OK, servicios);
    }

    [HttpGet("{idServicio}")]
    public async Task<IActionResult> GetServicioByIdAsync(byte idServicio)
    {
        var servicio = await serviceServicio.FindByIdAsync(idServicio);
        return StatusCode(StatusCodes.Status200OK, servicio);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ServicioDTO))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
    public async Task<IActionResult> CreateProductoAsync([FromBody] RequestServicioDTO servicio)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(servicio);
        var result = await serviceServicio.CreateServicioAsync(servicio);
        return StatusCode(StatusCodes.Status201Created, servicio);
    }
}