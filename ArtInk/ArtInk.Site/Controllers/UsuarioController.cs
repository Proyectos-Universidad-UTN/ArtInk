using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class UsuarioController(IAPIArtInkClient cliente) : Controller
{
    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<UsuarioResponseDto>>(Constantes.GET, Constantes.GETALLUSUARIOS);
        return View(collection);
    }
}