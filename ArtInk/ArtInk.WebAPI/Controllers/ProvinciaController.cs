using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
}