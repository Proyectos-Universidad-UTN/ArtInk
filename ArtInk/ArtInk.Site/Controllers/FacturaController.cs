using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class FacturaController(IAPIArtInkClient factura) : Controller
{
    public async Task<IActionResult> Index()
    {
        var collection = await factura.ConsumirAPIAsync<IEnumerable<FacturaResponseDto>>(Constantes.GET, Constantes.GETALLFACTURAS);
        return View(collection);
    }

    public async Task<IActionResult> Details(long id)
    {
        var url = string.Format(Constantes.GETFACTURABYID, id);
        var collection = await factura.ConsumirAPIAsync<FacturaResponseDto>(Constantes.GET, url);

        return View(collection);
    }
}