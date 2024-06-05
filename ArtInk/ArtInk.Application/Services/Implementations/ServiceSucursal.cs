using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs;
using ArtInk.Application.Services.Interfaces;
using ArtInk.Infraestructure.Models;
using ArtInk.Infraestructure.Repository.Interfaces;
using AutoMapper;

namespace ArtInk.Application.Services.Implementations;

public class ServiceSucursal(IRepositorySucursal repositorySucursal, IMapper mapper) : IServiceSucursal
{
    public async Task<SucursalDTO> CreateAsync(SucursalDTO sucursal)
    {
        var sucursalCreada = await repositorySucursal.CreateAsync(mapper.Map<Sucursal>(sucursal));
        if (sucursalCreada == null) throw new Exception("Sucursal no creada");

        return mapper.Map<SucursalDTO>(sucursalCreada);
    }

    public async Task<bool> DeleteAsync(byte id)
    {
        if (!await repositorySucursal.ExistsAsync(id)) throw new Exception("Sucursal no existe");
        return await repositorySucursal.DeleteAsync(id);
    }

    public async Task<SucursalDTO> GetByIdAsync(byte id)
    {
        var sucursal = await repositorySucursal.GetByIdAsync(id);
        if (sucursal == null) throw new Exception("Sucursal no existe");

        return mapper.Map<SucursalDTO>(sucursal);
    }

    public async Task<ICollection<SucursalDTO>> ListAsync()
    {
        var sucursales = await repositorySucursal.ListAsync();
        return mapper.Map<ICollection<SucursalDTO>>(sucursales);
    }

    public async Task<SucursalDTO> UpdateAsync(byte id, SucursalDTO sucursal)
    {
        if (!await repositorySucursal.ExistsAsync(id)) throw new Exception("Sucursal no existe");

        sucursal.Id = id;
        var sucursalActualizada = await repositorySucursal.UpdateAsync(mapper.Map<Sucursal>(sucursal));
        if (sucursalActualizada == null) throw new Exception("Sucursal no actualizada");
        
        return mapper.Map<SucursalDTO>(sucursalActualizada);
    }
}