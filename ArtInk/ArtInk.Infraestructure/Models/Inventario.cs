namespace ArtInk.Infraestructure.Models;

public partial class Inventario
{
    public short Id { get; set; }

    public byte IdSucursal { get; set; }

    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    public byte Minima { get; set; }

    public byte Maxima { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}