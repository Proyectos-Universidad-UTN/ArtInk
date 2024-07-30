using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Common
{
    public record SucursalReservas
    {
        public string UrlAPI { get; set; } = null!;

        public IEnumerable<SucursalResponseDto> Sucursales { get; set; } = null!;
    }
}
