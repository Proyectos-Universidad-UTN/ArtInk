using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnidadMedidaController(IServiceUnidadMedida serviceUnidadMedida) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllUnidadMedidasAsync()
    {
        var users = await serviceUnidadMedida.ListAsync();
        return StatusCode(StatusCodes.Status200OK, users);
    }
}