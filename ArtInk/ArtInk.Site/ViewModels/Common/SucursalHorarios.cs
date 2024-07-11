using ArtInk.Site.ViewModels.Response;

namespace ArtInk.Site.ViewModels.Common
{
    public record SucursalHorarios
    {
        public string UrlAPI { get; set; } = null!;

        public IEnumerable<SucursalResponseDTO> Sucursales { get; set; } = null!;
    }
}
