using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Common;

public class SucursalInventarioProducto
{
    public string UrlAPI { get; set; } = null!;

    public byte IdSucursal { get; set; }

    public List<SucursalResponseDto> Sucursales { get; set; } = null!;

    public List<InventarioResponseDto> Inventarios { get; set; } = new List<InventarioResponseDto>();
}