using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceInventarioProducto
{
    Task<InventarioProductoDto> GetInventarioProductoById(long id);
    
    Task<ICollection<InventarioProductoDto>> ListByInventarioAsync(short idInventario);

    Task<ICollection<InventarioProductoDto>> ListByProductoAsync(short idProducto);

    Task<InventarioProductoDto> AgregarProductoInventario(RequestInventarioProductoDto inventarioProductoDto);

    Task<bool> AgregarProductoInventario(IEnumerable<RequestInventarioProductoDto> inventarioProductosDto);

    Task<InventarioProductoDto> UpdateProductoInventario(long idInventarioProducto, RequestInventarioProductoDto inventarioProductoDto);
}