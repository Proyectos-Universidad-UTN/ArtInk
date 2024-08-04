using ArtInk.Application.Comunes;
using ArtInk.Application.Configuration.Pagination;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ArtInk.Application.Services.Implementations;

public class ServiceProveedor(IRepositoryProveedor repository, IMapper mapper, IValidator<Proveedor> proveedorValidator) : IServiceProveedor
{
    public async Task<ProveedorDto> CreateProveedorAsync(RequestProveedorDto proveedorDto)
    {
        var proveedor = await ValidarProveedor(proveedorDto);

        var result = await repository.CreateProveedorAsync(proveedor);
        if (result == null) throw new NotFoundException("Proveedor no creado.");
        return mapper.Map<ProveedorDto>(result);
    }

    public async Task<bool> DeleteProveedorsyncAsync(byte id)
    {
        if (!await repository.ExisteProveedor(id)) throw new NotFoundException("Proveedor no encontrada.");

        return await repository.DeleteProveedorAsync(id);
    }

    public async Task<ProveedorDto> FindByIdAsync(byte id)
    {
        var proveedor = await repository.GetByIdAsync(id);
        if (proveedor == null) throw new NotFoundException("Proveedor no encontrado.");

        return mapper.Map<ProveedorDto>(proveedor);
    }

    public async Task<ICollection<ProveedorDto>> ListAsync()
    {
        var proveedores = await repository.ListAllAsync();
        return mapper.Map<ICollection<ProveedorDto>>(proveedores);
    }

    public async Task<PagedList<ProveedorDto>> ListAsync(PaginationParameters paginationParameters)
    {
        var query = repository.ListAllQueryable();
        var paginatedCollection = await PagedList<Proveedor>.PaginatedCollection(query, paginationParameters.PageNumber, paginationParameters.PageSize);
        var proveedores = mapper.Map<ICollection<ProveedorDto>>(paginatedCollection);
        var count = await query.CountAsync();
        
        return PagedList<ProveedorDto>.ToPagedList(proveedores.ToList(), count, paginationParameters.PageNumber, paginationParameters.PageSize);
    }

    public async Task<ProveedorDto> UpdateProveedorsync(byte id, RequestProveedorDto proveedorDto)
    {
        if (!await repository.ExisteProveedor(id)) throw new NotFoundException("Proveedor no encontrada.");

        var proveedor = await ValidarProveedor(proveedorDto);
        proveedor.Id = id;
        var result = await repository.UpdateProveedorAsync(proveedor);

        return mapper.Map<ProveedorDto>(result);
    }

    private async Task<Proveedor> ValidarProveedor(RequestProveedorDto proveedorDto)
    {
        var proveedor = mapper.Map<Proveedor>(proveedorDto);
        await proveedorValidator.ValidateAndThrowAsync(proveedor);
        return proveedor;
    }
}