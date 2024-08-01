using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceProducto(IRepositoryProducto repository, IMapper mapper,
                                  IValidator<Producto> productoValidator) : IServiceProducto
{
    public async Task<ProductoDto> CreateProductoAsync(RequestProductoDto productoDTO)
    {
        var producto = await ValidarProducto(productoDTO);

        var result = await repository.CreateProductoAsync(producto);
        if (result == null) throw new NotFoundException("Producto no creado.");

        return mapper.Map<ProductoDto>(result);
    }
    public async Task<ProductoDto> UpdateProductoAsync(short id, RequestProductoDto productoDTO)
    {
        if (!await repository.ExisteProducto(id)) throw new NotFoundException("Producto no encontrada.");

        var producto = await ValidarProducto(productoDTO);
        producto.Id = id;
        var result = await repository.UpdateProductoAsync(producto);

        return mapper.Map<ProductoDto>(result);
    }

    public async Task<ProductoDto> FindByIdAsync(short id)
    {
        var producto = await repository.FindByIdAsync(id);
        if (producto == null) throw new NotFoundException("Producto no encontrado.");

        return mapper.Map<ProductoDto>(producto);
    }

    public async Task<ICollection<ProductoDto>> ListAsync(bool excludeProductosInventario = false, short idInventario = 0)
    {
        var list = await repository.ListAsync(excludeProductosInventario, idInventario);
        var collection = mapper.Map<ICollection<ProductoDto>>(list);

        return collection;
    }
    
    private async Task<Producto> ValidarProducto(RequestProductoDto productoDTO)
    {
        var producto = mapper.Map<Producto>(productoDTO);
        await productoValidator.ValidateAndThrowAsync(producto);
        return producto;
    }
}