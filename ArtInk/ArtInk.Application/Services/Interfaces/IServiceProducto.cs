using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceProducto
{
    Task<ICollection<ProductoDTO>> ListAsync();

    Task<ProductoDTO> FindByIdAsync(short id);

    Task<ProductoDTO> CreateProductoAsync(RequestProductoDTO productoDTO);

    Task<ProductoDTO> UpdateProductoAsync(short id, RequestProductoDTO productoDTO);
}