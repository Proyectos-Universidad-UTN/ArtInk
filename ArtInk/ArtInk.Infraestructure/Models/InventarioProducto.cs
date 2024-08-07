namespace ArtInk.Infraestructure.Models;

public partial class InventarioProducto
{
    public long Id { get; set; }

    public short IdInventario { get; set; }

    public short IdProducto { get; set; }

    public decimal Disponible { get; set; }

    public decimal Minima { get; set; }

    public decimal Maxima { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Inventario IdInventarioNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual ICollection<InventarioProductoMovimiento> InventarioProductoMovimientos { get; set; } = new List<InventarioProductoMovimiento>();
}