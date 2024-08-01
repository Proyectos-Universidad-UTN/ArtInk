using ArtInk.Application.DTOs;
using ArtInk.Application.RequestDTOs;

namespace ArtInk.Application.Services.Interfaces;

public interface IServiceInventarioProductoMovimiento
{
    Task<ICollection<InventarioProductoMovimientoDto>> ObtenerMovimientosInventarioByInventario(short idInventario);

    Task<ICollection<InventarioProductoMovimientoDto>> ObtenerMovimientosInventarioByProducto(short idProducto);

    Task<bool> AgregarInventarioMovimientoProducto(RequestInventarioProductoMovimientoDto inventarioProductoMovimientoDto);
}