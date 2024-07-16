using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceInventario
{
    Task<ICollection<InventarioDto>> ListAsync();

    Task<ICollection<InventarioDto>> ListAsync(byte idSucursal);

    Task<InventarioDto> FindByIdAsync(short id);

    Task<InventarioDto> CreateInventarioAsync(byte idSucursal, RequestInventarioDto productoDTO);

    Task<InventarioDto> UpdateInventarioAsync(byte idSucursal, short id, RequestInventarioDto productoDTO);

    Task<bool> DeleteInventarioAsync(short id);
}