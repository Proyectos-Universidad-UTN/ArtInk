using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class HorarioController(IAPIArtInkClient cliente) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<SucursalResponseDTO>>(Constantes.GET, Constantes.GETALLSUCURSALES);
            if (collection == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index", "Home");
            }
            return View(collection);
        }

        public async Task<IActionResult> Details(short id)
        {
            var url = string.Format(Constantes.GETHORARIOBYID, id);
            var collection = await cliente.ConsumirAPIAsync<HorarioResponseDTO>(Constantes.GET, url);

            return View(collection);
        }
    }
}
