using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController(IServiceDetalleFactura serviceDetalleFactura) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDetalleFacturasAsync()
        {
            var detalleFacturas = await serviceDetalleFactura.ListAsync();
            return StatusCode(StatusCodes.Status200OK, detalleFacturas);
        }

        [HttpGet("{idDetalleFacturas}")]
        public async Task<IActionResult> GetDetalleFacturasByIdAsync(int idDetalleFactura)
        {
            var detalleFacturas = await serviceDetalleFactura.FindByIdAsync(idDetalleFactura);
            return StatusCode(StatusCodes.Status200OK, detalleFacturas);
        }
    }
}
