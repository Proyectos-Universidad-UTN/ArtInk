
using ArtInk.Infraestructure.Models;

namespace ArtInk.Infraestructure.Repository.Interfaces;

public interface IRepositoryInventarioProductoMovimiento
{
    Task<ICollection<InventarioProductoMovimiento>> ObtenerMovimientosInventarioByInventario(short idInventario);

    Task<ICollection<InventarioProductoMovimiento>> ObtenerMovimientosInventarioByProducto(short idProducto);

    Task<bool> AgregarInventarioMovimientoProducto(InventarioProductoMovimiento inventarioProductoMovimiento);
}