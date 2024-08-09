using ArtInk.Application.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class DistritoController(IServiceDistrito serviceDistrito) : ControllerBase
{
    [HttpGet("~/api/Canton/{idCanton}/Distrito")]
    public async Task<IActionResult> GetAllDistritosByCantonAsync(byte idCanton)
    {
        var users = await serviceDistrito.ListAsync(idCanton);
        return StatusCode(StatusCodes.Status200OK, users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDistritoAsync(byte id)
    {
        var users = await serviceDistrito.FindByIdAsync(id);
        return StatusCode(StatusCodes.Status200OK, users);
    }
}