using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Application.DTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceSucursal
{
    Task<ICollection<SucursalDTO>> ListAsync();

    Task<SucursalDTO> GetByIdAsync(byte id);

    Task<SucursalDTO> CreateAsync(SucursalDTO sucursal);

    Task<SucursalDTO> UpdateAsync(byte id, SucursalDTO sucursal);

    Task<bool> DeleteAsync(byte id);
}