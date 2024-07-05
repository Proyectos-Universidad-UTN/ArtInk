using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Implementations;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController(IServiceServicio serviceServicio) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ServicioDTO>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
        public async Task<IActionResult> GetAllServiciosAsync()
        {
            var servicios = await serviceServicio.ListAsync();
            return StatusCode(StatusCodes.Status200OK, servicios);
        }

        [HttpGet("{idServicio}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServicioDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
        public async Task<IActionResult> GetServicioByIdAsync(byte idServicio)
        {
            var servicio = await serviceServicio.FindByIdAsync(idServicio);
            return StatusCode(StatusCodes.Status200OK, servicio);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ServicioDTO))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
        public async Task<IActionResult> CreateProductoAsync([FromBody] RequestServicioDTO servicio)
        {
            //retorna una excepçión is es nulo
            ArgumentNullException.ThrowIfNull(servicio);
            var result = await serviceServicio.CreateServicioAsync(servicio);
            return StatusCode(StatusCodes.Status201Created, servicio);
        }

        [HttpPut("{idServicio}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServicioDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
        public async Task<IActionResult> UpdateSucursalAsync(byte idServicio, [FromBody] RequestServicioDTO servicio)
        {
            //retorna una excepçión is es nulo
            ArgumentNullException.ThrowIfNull(servicio);
            var result = await serviceServicio.UpdateServicioAsync(idServicio, servicio);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
