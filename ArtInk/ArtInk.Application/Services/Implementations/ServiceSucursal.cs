using ArtInk.Application.Comunes;
using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace ArtInk.Application.Services.Implementations;

public class ServiceSucursal(IRepositorySucursal repository, IMapper mapper,
                                IValidator<Sucursal> sucursalValidator) : IServiceSucursal
{
    public async Task<SucursalDto> CreateSucursalAsync(RequestSucursalDto sucursalDTO)
    {
        var sucursal = await ValidarSucursal(sucursalDTO);

        var result = await repository.CreateSucursalAsync(sucursal);
        if (result == null) throw new NotFoundException("Sucursal no se ha creado.");

        return mapper.Map<SucursalDto>(result);
    }

    public async Task<SucursalDto> UpdateSucursalAsync(byte id, RequestSucursalDto sucursalDTO)
    {
        if (!await repository.ExisteSucursal(id)) throw new NotFoundException("Sucursal no encontrada.");

        var sucursal = await ValidarSucursal(sucursalDTO);
        sucursal.Id = id;
        var result = await repository.UpdateSucursalAsync(sucursal);

        return mapper.Map<SucursalDto>(result);
    }

    public async Task<SucursalDto> FindByIdAsync(byte id)
    {
        var sucursal = await repository.FindByIdAsync(id);
        if (sucursal == null) throw new NotFoundException("Sucursal no encontrada.");

        return mapper.Map<SucursalDto>(sucursal);
    }

    public async Task<ICollection<SucursalDto>> ListAsync()
    {
        var list = await repository.ListAsync();
        var collection = mapper.Map<ICollection<SucursalDto>>(list);

        return collection;
    }

    private async Task<Sucursal> ValidarSucursal(RequestSucursalDto sucursalDTO)
    {
        var sucursal = mapper.Map<Sucursal>(sucursalDTO);
        await sucursalValidator.ValidateAndThrowAsync(sucursal);
        return sucursal;
    }
}