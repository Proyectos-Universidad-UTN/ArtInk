using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController(IServiceSucursal serviceSucursal) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSucursalesAsync()
        {
            var sucursales = await serviceSucursal.ListAsync();
            return StatusCode(StatusCodes.Status200OK, sucursales);
        }

        [HttpGet("{idSucursal}")]
        public async Task<IActionResult> GetSucursalByIdAsync(byte idSucursal)
        {
            var sucursal = await serviceSucursal.FindByIdAsync(idSucursal);
            return StatusCode(StatusCodes.Status200OK, sucursal);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SucursalDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Exception))]
        public async Task<IActionResult> CreateSucursalAsync([FromBody] RequestSucursalDTO sucursal)
        {
            //retorna una excepçión is es nulo
            ArgumentNullException.ThrowIfNull(sucursal);
            var result = await serviceSucursal.CreateSucursalAsync(sucursal);
            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
