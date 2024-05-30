using ArtInk.Site.Client;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class UsuarioController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await APIArtInkClient.ConsumirAPIAsync<IEnumerable<UsuarioResponseDTO>>("application/json", "GET", "http://localhost:5191/api/Usuario", new Dictionary<string, string>(), string.Empty);
            return View(collection);
        }
    }
}
