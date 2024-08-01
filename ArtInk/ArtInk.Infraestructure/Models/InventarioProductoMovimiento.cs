using ArtInk.Infraestructure.Enums;

namespace ArtInk.Infraestructure.Models;

public partial class InventarioProductoMovimiento
{
    public long Id { get; set; }

    public long IdInventarioProducto { get; set; }

    public TipoMovimientoInventario TipoMovimiento { get; set; }

    public decimal Cantidad { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual InventarioProducto IdInventarioProductoNavigation { get; set; } = null!;
}