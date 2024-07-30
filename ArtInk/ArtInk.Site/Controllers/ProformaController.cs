using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

[Route("[controller]")]
public class ProformaController(IApiArtInkClient cliente) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<PedidoResponseDto>>(Constantes.GET, Constantes.GETALLPEDIDOS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }
        return View(collection);
    }

    // public async Task<IActionResult> Create()
    // {

    // }

    // private async Task<(bool, List<ClienteResponseDto>, List<ImpuestoResponseDto>, List<TipoPagoResponseDto>) ObtenerValoresInicialesForm()
    // {
     
    // }
}