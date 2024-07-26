namespace ArtInk.Site.ViewModels.Response;

public class InventarioProductoResponseDto
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

    public virtual InventarioResponseDto Inventario { get; set; } = null!;

    public virtual ProductoResponseDto Producto { get; set; } = null!;
}