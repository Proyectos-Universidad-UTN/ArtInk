using ArtInk.Infraestructure.Enums;

namespace ArtInk.Infraestructure.Models;

public partial class InventarioProductoMovimiento: BaseModel
{
    public long Id { get; set; }

    public long IdInventarioProducto { get; set; }

    public TipoMovimientoInventario TipoMovimiento { get; set; }

    public decimal Cantidad { get; set; }

    public virtual InventarioProducto IdInventarioProductoNavigation { get; set; } = null!;
}