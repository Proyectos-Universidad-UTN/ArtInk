using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record InventarioResponseDto
{
    public short Id { get; set; }

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    [DisplayName("Producto")]
    public short IdProducto { get; set; }

    public byte Disponible { get; set; }

    [DisplayName("Mínima")]
    public byte Minima { get; set; }

    [DisplayName("Máxima")]
    public byte Maxima { get; set; }

    public virtual ProductoResponseDto Producto { get; set; } = null!;

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;
}