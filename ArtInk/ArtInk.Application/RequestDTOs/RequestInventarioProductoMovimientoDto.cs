using ArtInk.Application.DTOs.Enums;

namespace ArtInk.Application.RequestDTOs;

public record RequestInventarioProductoMovimientoDto: RequestBaseDTO
{
    public long Id { get; set; }

    public long IdInventarioProducto { get; set; }

    public TipoMovimientoInventario TipoMovimiento { get; set; }

    public decimal Cantidad { get; set; }
}