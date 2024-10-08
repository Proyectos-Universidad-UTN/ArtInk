﻿using ArtInk.Application.DTOs;
using ArtInk.Application.DTOs.Enums;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.WebAPI.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.WebAPI.Controllers;

[ApiController]
[ArtInkAuthorize]
[Route("api/[controller]")]
[Authorize(Policy = "ArtInk")]
public class SucursalController(IServiceSucursal serviceSucursal) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SucursalDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllSucursalesAsync()
    {
        var sucursales = await serviceSucursal.ListAsync();
        return StatusCode(StatusCodes.Status200OK, sucursales);
    }

    [HttpGet("ByRol")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SucursalDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetAllSucursalesByRolAsync()
    {
        var sucursales = await serviceSucursal.ListByRolAsync();
        return StatusCode(StatusCodes.Status200OK, sucursales);
    }

    [HttpGet("{idSucursal}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> GetSucursalByIdAsync(byte idSucursal)
    {
        var sucursal = await serviceSucursal.FindByIdAsync(idSucursal);
        return StatusCode(StatusCodes.Status200OK, sucursal);
    }

    [HttpPost]
    [ArtInkAuthorize(Rol.ADMINISTRADOR)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SucursalDto))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> CreateSucursalAsync([FromBody] RequestSucursalDto sucursal)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(sucursal);
        var result = await serviceSucursal.CreateSucursalAsync(sucursal);
        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPut("{idSucursal}")]
    [ArtInkAuthorize(Rol.ADMINISTRADOR)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SucursalDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ErrorDetailsArtInk))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetailsArtInk))]
    public async Task<IActionResult> UpdateSucursalAsync(byte idSucursal, [FromBody] RequestSucursalDto sucursal)
    {
        //retorna una excepçión is es nulo
        ArgumentNullException.ThrowIfNull(sucursal);
        var result = await serviceSucursal.UpdateSucursalAsync(idSucursal, sucursal);
        return StatusCode(StatusCodes.Status200OK, result);
    }
}