using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ProvinciaController(IApiArtInkClient cliente) : Controller
{
    public async Task<IEnumerable<ProvinciaResponseDto>> ObtenerProvincias()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        return collection;
    }
}