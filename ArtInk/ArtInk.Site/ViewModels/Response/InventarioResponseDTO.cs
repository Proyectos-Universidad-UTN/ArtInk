using System.ComponentModel;

namespace ArtInk.Site.ViewModels.Response;

public record InventarioResponseDto
{
    public short Id { get; set; }

    public string Nombre { get; set; } = null!;

    [DisplayName("Sucursal")]
    public byte IdSucursal { get; set; }

    public bool Activo { get; set; }

    public virtual SucursalResponseDto Sucursal { get; set; } = null!;

    public virtual ICollection<InventarioProductoResponseDto> InventarioProductos { get; set; } = new List<InventarioProductoResponseDto>();
}