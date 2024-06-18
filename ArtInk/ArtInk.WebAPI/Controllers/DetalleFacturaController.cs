using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
}
