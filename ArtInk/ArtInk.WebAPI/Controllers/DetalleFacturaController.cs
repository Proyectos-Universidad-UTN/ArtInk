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
public class DetalleFacturaController(IServiceDetalleFactura serviceDetalleFactura) : ControllerBase
{
    //Formato del endpoint: el controller sería el de DetalleFactura
    [HttpGet("~/api/Factura/{idFactura}/[controller]")]
    public async Task<IActionResult> GetAllDetalleFacturaByFacturaAsync(long idFactura)
    {
        var detalleFacturas = await serviceDetalleFactura.ListAsync(idFactura);
        return StatusCode(StatusCodes.Status200OK, detalleFacturas);
    }

    [HttpGet("~/api/Factura/{idFactura}/[controller]/{idDetalleFactura}")]
    public async Task<IActionResult> GetDetalleFacturaByIdAsync(long idFactura, long idDetalleFactura)
    {
        var detalleFactura = await serviceDetalleFactura.FindByIdAsync(idFactura, idDetalleFactura);
        return StatusCode(StatusCodes.Status200OK, detalleFactura);
    }
}