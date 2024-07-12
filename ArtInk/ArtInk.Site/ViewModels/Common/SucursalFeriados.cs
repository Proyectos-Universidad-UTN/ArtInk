using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Common;

public record SucursalFeriados
{
    public string UrlAPI { get; set; } = null!;
    
    public IEnumerable<int> Annos { get; set; } = null!;

    public IEnumerable<SucursalResponseDto> Sucursales { get; set; } = null!;
}