using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceInventario(IRepositoryInventario repository, IMapper mapper, IValidator<Inventario> inventarioValidator) : IServiceInventario
{
    public async Task<InventarioDto> CreateInventarioAsync(byte idSucursal, RequestInventarioDto productoDTO)
    {
        var inventario = await ValidarInventario(productoDTO);
        inventario.IdSucursal = idSucursal;

        var result = await repository.CreateInventarioAsync(inventario);
        if (result == null) throw new NotFoundException("Inventario no creado.");

        return mapper.Map<InventarioDto>(result);
    }

    public async Task<bool> DeleteInventarioAsync(short id)
    {
        if (!await repository.ExisteInventario(id)) throw new NotFoundException("Inventario no encontrada.");

        var inventario = await FindByIdAsync(id);
        if(inventario!.InventarioProductos.Any(m => m.Disponible != 0)) throw new ArtInkException("No puede eliminar un inventario con productos disponibles, asegurese que todos los productos tengan cantidad 0 antes de eliminar el inventario");

        return await repository.DeleteInventarioAsync(id);
    }

    public async Task<InventarioDto> FindByIdAsync(short id)
    {
        var inventario = await repository.FindByIdAsync(id);
        if (inventario == null) throw new NotFoundException("Inventario no encontrado.");

        return mapper.Map<InventarioDto>(inventario);
    }

    public async Task<ICollection<InventarioDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<InventarioDto>>(list);

        return collection;
    }

    public async Task<ICollection<InventarioDto>> ListAsync(byte idSucursal)
    {
        var list = await repository.ListAsync(idSucursal);
        var collection = mapper.Map<ICollection<InventarioDto>>(list);

        return collection;
    }

    public async Task<InventarioDto> UpdateInventarioAsync(byte idSucursal, short id, RequestInventarioDto productoDTO)
    {
        if (!await repository.ExisteInventario(id)) throw new NotFoundException("Inventario no encontrada.");

        var inventario = await ValidarInventario(productoDTO);
        inventario.IdSucursal = idSucursal;
        inventario.Id = id;
        var result = await repository.UpdateInventarioAsync(inventario);

        return mapper.Map<InventarioDto>(result);
    }

    private async Task<Inventario> ValidarInventario(RequestInventarioDto inventarioDto)
    {
        var inventario = mapper.Map<Inventario>(inventarioDto);
        await inventarioValidator.ValidateAndThrowAsync(inventario);
        return inventario;
    }
}