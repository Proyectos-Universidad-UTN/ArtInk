using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ProvinciaController(IAPIArtInkClient cliente) : Controller
{
    public async Task<IEnumerable<ProvinciaResponseDto>> ObtenerProvincias()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        return collection;
    }

    public async Task<ProvinciaResponseDto> ObtenerProvincia(byte id)
    {
        var url = string.Format(Constantes.GETPROVINCIABYID, id);
        var collection = await cliente.ConsumirAPIAsync<ProvinciaResponseDto>(Constantes.GET, url);

        return collection;
    }
}