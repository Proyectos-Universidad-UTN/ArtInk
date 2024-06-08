using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class ProductoController(IAPIArtInkClient cliente) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<ProductoResponseDTO>>(Constantes.GET, Constantes.GETALLPRODUCTOS);
            return View(collection);
        }

        public async Task<IActionResult> Details(short id)
        {
            var url = string.Format(Constantes.GETPRODUCTOBYID, id);
            var collection = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.GET, url);

            return View(collection);
        }
    }
}
