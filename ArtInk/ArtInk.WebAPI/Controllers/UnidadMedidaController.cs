using ArtInk.Application.Services.Interfaces;
using ArtInk.WebAPI.Configuration;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[ArtInkAuthorize]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Authorize(Policy = "ArtInk")]
public class UnidadMedidaController(IServiceUnidadMedida serviceUnidadMedida) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUnidadMedidasAsync()
    {
        var users = await serviceUnidadMedida.ListAsync();
        return StatusCode(StatusCodes.Status200OK, users);
    }
}