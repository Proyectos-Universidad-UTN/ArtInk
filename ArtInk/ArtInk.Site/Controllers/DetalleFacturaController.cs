using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class DetalleFacturaController(IAPIArtInkClient detalleFactura) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await detalleFactura.ConsumirAPIAsync<IEnumerable<DetalleFacturaResponseDTO>>(Constantes.GET, Constantes.GETALLDETALLEFACTURAS);
            return View(collection);
        }

        public async Task<IActionResult> Details(int id)
        {
            var url = string.Format(Constantes.GETDETALLEFACTURABYID, id);
            var collection = await detalleFactura.ConsumirAPIAsync<DetalleFacturaResponseDTO>(Constantes.GET, url);

            return View(collection);
        }
    }
}
