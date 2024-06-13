﻿using ArtInk.Application.Services.Interfaces;
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
    }
}
