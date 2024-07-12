using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ReservaPreguntaController(IAPIArtInkClient cliente) : Controller
{
    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ReservaPreguntaResponseDto>>(Constantes.GET, Constantes.GETALLRESERVASPREGUNTAS);
        return View(collection);
    }

    public async Task<IActionResult> Details(int id)
    {
        var url = string.Format(Constantes.GETRESERVABYID, id);
        var collection = await cliente.ConsumirAPIAsync<ReservaPreguntaResponseDto>(Constantes.GET, url);

        return View(collection);
    }
}