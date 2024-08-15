using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class RolController(IApiArtInkClient cliente): BaseArtInkController
{
    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<RolResponseDto>>(Constantes.GET, Constantes.GETALLROLS);
        return View(collection);
    }
}