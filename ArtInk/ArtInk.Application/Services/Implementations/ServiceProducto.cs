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
    public async Task<ProductoDTO> CreateProductoAsync(RequestProductoDTO productoDTO)
    {
        var producto = await ValidarProducto(productoDTO);

        var result = await repository.CreateProductoAsync(producto);
        if (result == null) throw new NotFoundException("Producto no creado.");

        return mapper.Map<ProductoDTO>(result);
    }
    public async Task<ProductoDTO> UpdateProductoAsync(short id, RequestProductoDTO productoDTO)
    {
        if (!await repository.ExisteProducto(id)) throw new NotFoundException("Producto no encontrada.");

        var producto = await ValidarProducto(productoDTO);
        producto.Id = id;
        var result = await repository.UpdateProductoAsync(producto);

        return mapper.Map<ProductoDTO>(result);
    }

    public async Task<ProductoDTO> FindByIdAsync(short id)
    {
        var producto = await repository.FindByIdAsync(id);
        if (producto == null) throw new NotFoundException("Producto no encontrado.");

        return mapper.Map<ProductoDTO>(producto);
    }
    public async Task<ICollection<ProductoDTO>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<ProductoDTO>>(list);

        return collection;
    }
    private async Task<Producto> ValidarProducto(RequestProductoDTO productoDTO)
    {
        var producto = mapper.Map<Producto>(productoDTO);
        await productoValidator.ValidateAndThrowAsync(producto);
        return producto;
    }

}
