using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Common;

public class SucursalInventario
{
    public string UrlAPI { get; set; } = null!;

    public IEnumerable<SucursalResponseDto> Sucursales { get; set; } = null!;
}