using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceInventarioProducto(IRepositoryInventarioProducto repository, IMapper mapper,
                                    IValidator<InventarioProducto> inventarioProductoValidator) : IServiceInventarioProducto
{
    public async Task<InventarioProductoDto> AgregarProductoInventario(RequestInventarioProductoDto inventarioProductoDto)
    {
        var inventarioProducto = await ValidarInventarioProducto(inventarioProductoDto);

        var result = await repository.AgregarProductoInventario(inventarioProducto);
         if (result == null) throw new NotFoundException("Inventario producto no creado.");

        return mapper.Map<InventarioProductoDto>(result);
    }

    public async Task<bool> AgregarProductoInventario(IEnumerable<RequestInventarioProductoDto> inventarioProductosDto)
    {
        var inventarioProductos = await ValidarInventarioProducto(inventarioProductosDto);
        var result = await repository.AgregarProductoInventario(inventarioProductos);
        if (!result) throw new ListNotAddedException("Error al guardar inventario productos.");

        return result;
    }

    public async Task<InventarioProductoDto> GetInventarioProductoById(long id)
    {
        var inventarioProducto = await repository.GetInventarioProductoById(id);
        if (inventarioProducto == null) throw new NotFoundException("Inventario producto no encontrado.");

        return mapper.Map<InventarioProductoDto>(inventarioProducto);
    }

    public async Task<ICollection<InventarioProductoDto>> ListByInventarioAsync(short idInventario)
    {
        var list = await repository.ListByInventarioAsync(idInventario);
        var collection = mapper.Map<ICollection<InventarioProductoDto>>(list);

        return collection;
    }

    public async Task<ICollection<InventarioProductoDto>> ListByProductoAsync(short idProducto)
    {
        var list = await repository.ListByProductoAsync(idProducto);
        var collection = mapper.Map<ICollection<InventarioProductoDto>>(list);

        return collection;
    }

    public async Task<InventarioProductoDto> UpdateProductoInventario(long idInventarioProducto, RequestInventarioProductoDto inventarioProductoDto)
    {
        if(!await repository.ExisteInventarioProducto(idInventarioProducto)) throw new NotFoundException("Inventario producto no encontrada."); 

        var inventarioProducto = await ValidarInventarioProducto(inventarioProductoDto);
        inventarioProducto.Id = idInventarioProducto;
        var result = await repository.UpdateProductoInventario(inventarioProducto);

        return mapper.Map<InventarioProductoDto>(result);
    }

    private async Task<InventarioProducto> ValidarInventarioProducto(RequestInventarioProductoDto inventarioProductoDto)
    {
        var inventarioProducto = mapper.Map<InventarioProducto>(inventarioProductoDto);
        await inventarioProductoValidator.ValidateAndThrowAsync(inventarioProducto);
        return inventarioProducto;
    } 

    private async Task<IEnumerable<InventarioProducto>> ValidarInventarioProducto(IEnumerable<RequestInventarioProductoDto> inventarioProductosDto)
    {
        var inventarioProductos = mapper.Map<List<InventarioProducto>>(inventarioProductosDto);
        foreach (var item in inventarioProductos)
        {
            await inventarioProductoValidator.ValidateAndThrowAsync(item);
        }
        return inventarioProductos;
    }
}