using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Infraestructure.Enums;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceInventarioProductoMovimiento(IRepositoryInventarioProductoMovimiento repository, IRepositoryInventarioProducto repositoryInventarioProducto,
                                                IMapper mapper, IValidator<InventarioProductoMovimiento> inventarioProductoMovimientoValidator) : IServiceInventarioProductoMovimiento
{
    public async Task<bool> AgregarInventarioMovimientoProducto(RequestInventarioProductoMovimientoDto inventarioProductoMovimientoDto)
    {
        var inventarioProductoMovimiento = await ValidarInventarioProductoMovimiento(inventarioProductoMovimientoDto);

        var inventarioProducto = await repositoryInventarioProducto.GetInventarioProductoById(inventarioProductoMovimiento.IdInventarioProducto);
        if (inventarioProducto == null) throw new NotFoundException("Inventario producto no creado.");

        if (inventarioProductoMovimiento.TipoMovimiento == TipoMovimientoInventario.Salida && inventarioProducto.Disponible - inventarioProductoMovimiento.Cantidad < 0)
            throw new ArtInkException("No puede generar un movimiento de inventario con una cantidad mayor a la disponible.");

        var nuevaCantidadDisponible = inventarioProductoMovimientoDto.TipoMovimiento == DTOs.Enums.TipoMovimientoInventario.Entrada ?
                            inventarioProductoMovimiento.Cantidad : inventarioProductoMovimiento.Cantidad * -1 + inventarioProducto.Disponible;

        if (nuevaCantidadDisponible > inventarioProducto.Maxima)
            throw new ArtInkException("Cantidad nueva disponible excede el máximo asignado.");

        if (nuevaCantidadDisponible < inventarioProducto.Minima)
            throw new ArtInkException("Cantidad nueva disponible es menor al mínimo asignado.");

        var result = await repository.AgregarInventarioMovimientoProducto(inventarioProductoMovimiento);
        if (!result) throw new NotFoundException("Movimiento inventario no creado.");

        return result;
    }

    public async Task<ICollection<InventarioProductoMovimientoDto>> ObtenerMovimientosInventarioByInventario(short idInventario)
    {
        var list = await repository.ObtenerMovimientosInventarioByInventario(idInventario);
        var collection = mapper.Map<ICollection<InventarioProductoMovimientoDto>>(list);

        return collection;
    }

    public async Task<ICollection<InventarioProductoMovimientoDto>> ObtenerMovimientosInventarioByProducto(short idProducto)
    {
        var list = await repository.ObtenerMovimientosInventarioByProducto(idProducto);
        var collection = mapper.Map<ICollection<InventarioProductoMovimientoDto>>(list);

        return collection;
    }

    private async Task<InventarioProductoMovimiento> ValidarInventarioProductoMovimiento(RequestInventarioProductoMovimientoDto inventarioProductoMovimientoDto)
    {
        var inventarioProductoMovimiento = mapper.Map<InventarioProductoMovimiento>(inventarioProductoMovimientoDto);
        await inventarioProductoMovimientoValidator.ValidateAndThrowAsync(inventarioProductoMovimiento);
        return inventarioProductoMovimiento;
    }
}