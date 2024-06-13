using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class ServicioController(IAPIArtInkClient cliente) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<ServicioResponseDTO>>(Constantes.GET, Constantes.GETALLSERVICIOS);
            return View(collection);
        }

        public async Task<IActionResult> Details(byte id)
        {
            var url = string.Format(Constantes.GETSERVICIOBYID, id);
            var collection = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.GET, url);

            return View(collection);
        }
    }
}
