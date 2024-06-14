using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController(IServiceDetalleFactura serviceDetalleFactura) : ControllerBase
    {
        [HttpGet("{idFactura}")]
        public async Task<IActionResult> GetAllDetalleFacturasAsync(long idFactura)
        {
            var detalleFacturas = await serviceDetalleFactura.ListAsync(idFactura);
            return StatusCode(StatusCodes.Status200OK, detalleFacturas);
        }

        //[HttpGet("{idDetalleFactura}")]
        //public async Task<IActionResult> GetDetalleFacturaByIdAsync(long idDetalleFactura)
        //{
        //    var detalleFactura = await serviceDetalleFactura.FindByIdAsync(idDetalleFactura);
        //    return StatusCode(StatusCodes.Status200OK, detalleFactura);
        //}
    }
}
