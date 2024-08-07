using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class CantonController(IApiArtInkClient cantonCliente) : Controller
{
    [HttpPost]
    public async Task<IActionResult> ObtenerCantones(Direcciones direcciones)
    {
        var url = string.Format(Constantes.GETALLCANTONESBYPROVINCIA, direcciones.IdProvincia);
        var collection = await cantonCliente.ConsumirAPIAsync<List<CantonResponseDto>>(Constantes.GET, url);
        collection.Insert(0, new CantonResponseDto() { Id = 0, Nombre = "Seleccione un cantón" });
        direcciones.Cantones = collection;
        return PartialView("~/Views/Shared/_CantonSelect.cshtml", direcciones);
    }
}