using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CantonController(IServiceCanton serviceCanton) : ControllerBase
    {
        [HttpGet("~/api/Provincia/{idProvincia}/Canton")]
        public async Task<IActionResult> GetAllCantonesByProvinciaAsync(byte idProvincia)
        {
            var users = await serviceCanton.ListAsync(idProvincia);
            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCantonAsync(byte id)
        {
            var users = await serviceCanton.FindByIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, users);
        }
    }
}