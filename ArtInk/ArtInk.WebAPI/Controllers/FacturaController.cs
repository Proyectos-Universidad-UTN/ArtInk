using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacturaController(IServiceFactura serviceFactura) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllFacturasAsync()
    {
        var facturas = await serviceFactura.ListAsync();
        return StatusCode(StatusCodes.Status200OK, facturas);
    }

    [HttpGet("{idFactura}")]
    public async Task<IActionResult> GetFacturaByIdAsync(long idFactura)
    {
        var factura = await serviceFactura.FindByIdAsync(idFactura);
        return StatusCode(StatusCodes.Status200OK, factura);
    }
}