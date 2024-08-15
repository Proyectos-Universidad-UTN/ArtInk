using ArtInk.Application.Services.Interfaces;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[AllowAnonymous]
[ApiVersion("1.0")]
[Route("api/[controller]")]
public class ProvinciaController(IServiceProvincia serviceProvincia) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProvinciasAsync()
    {
        var provincias = await serviceProvincia.ListAsync();
        return StatusCode(StatusCodes.Status200OK, provincias);
    }

    [HttpGet("{idProvincia}")]
    public async Task<IActionResult> GetProvinciaByIdAsync(byte idProvincia)
    {
        var provincia = await serviceProvincia.FindByIdAsync(idProvincia);
        return StatusCode(StatusCodes.Status200OK, provincia);
    }
}