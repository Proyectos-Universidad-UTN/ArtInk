using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceProducto
{
    Task<ICollection<ProductoDto>> ListAsync(bool excludeProductosInventario = false, short idInventario = 0);

    Task<ProductoDto> FindByIdAsync(short id);

    Task<ProductoDto> CreateProductoAsync(RequestProductoDto productoDTO);

    Task<ProductoDto> UpdateProductoAsync(short id, RequestProductoDto productoDTO);
}