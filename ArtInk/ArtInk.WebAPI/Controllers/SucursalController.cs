using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SucursalController(IServiceSucursal serviceSucursal) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyCollection<SucursalDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var sucursales = await serviceSucursal.ListAsync();
            return StatusCode(StatusCodes.Status200OK, sucursales);
        }

        [HttpGet("{idSucursal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> GetGyIdAsync(byte idSucursal)
        {
            var sucursal = await serviceSucursal.GetByIdAsync(idSucursal);
            return StatusCode(StatusCodes.Status200OK, sucursal);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> CreateAsync([FromBody] SucursalDTO sucursalDTO)
        {
            var sucursal = await serviceSucursal.CreateAsync(sucursalDTO);
            return StatusCode(StatusCodes.Status200OK, sucursal);
        }

        [HttpPut("{idSucursal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> UpdateAsync(byte idSucursal, [FromBody] SucursalDTO sucursalDTO)
        {
            var sucursal = await serviceSucursal.UpdateAsync(idSucursal, sucursalDTO);
            return StatusCode(StatusCodes.Status200OK, sucursal);
        }

        [HttpDelete("{idSucursal}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public async Task<IActionResult> DeleteAsync(byte idSucursal)
        {
            var result = await serviceSucursal.DeleteAsync(idSucursal);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}

//Ejemplo create
// {
//   "fechaCreacion": "2024-06-05T07:42:45.237Z",
//   "usuarioCreacion": "API",
//   "nombre": "Sucursal 1",
//   "descripcion": "Sucursal de prueba",
//   "telefono": 22589410,
//   "correoElectronico": "suc@artink.com",
//   "idDistrito": 250,
//   "direccionExacta": "Del parque, 250 metros norte"
// }