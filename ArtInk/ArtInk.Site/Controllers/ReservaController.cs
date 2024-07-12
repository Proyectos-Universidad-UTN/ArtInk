using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ReservaController(IAPIArtInkClient cliente) : Controller
{
    public async Task<IActionResult> Index()
    {
        var url = string.Format(Constantes.GETALLRESERVASBYROL, "1");
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ReservaResponseDto>>(Constantes.GET, url);
        return View(collection);
    }

    public async Task<IActionResult> Details(int id)
    {
        var url = string.Format(Constantes.GETRESERVABYID, id);
        var collection = await cliente.ConsumirAPIAsync<ReservaResponseDto>(Constantes.GET, url);

        return View(collection);
    }
}