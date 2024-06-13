using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class ReservaController(IAPIArtInkClient cliente) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<ReservaResponseDTO>>(Constantes.GET, Constantes.GETALLRESERVAS);
            return View(collection);
        }

        public async Task<IActionResult> Details(int id)
        {
            var url = string.Format(Constantes.GETRESERVABYID, id);
            var collection = await cliente.ConsumirAPIAsync<ReservaResponseDTO>(Constantes.GET, url);

            return View(collection);
        }
    }
}

