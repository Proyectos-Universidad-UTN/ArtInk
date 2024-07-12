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
        var collection = new List<CantonResponseDto>();

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Error con los valores del formulario";
            collection.Insert(0, new CantonResponseDto() { Id = 0, Nombre = "Seleccione un cantón" });
            direcciones.Cantones = collection;
            return PartialView("~/Views/Shared/_CantonSelect.cshtml", direcciones);
        }

        var url = string.Format(Constantes.GETALLCANTONESBYPROVINCIA, direcciones.IdProvincia);
        collection = await cantonCliente.ConsumirAPIAsync<List<CantonResponseDto>>(Constantes.GET, url);
        collection.Insert(0, new CantonResponseDto() { Id = 0, Nombre = "Seleccione un cantón" });
        direcciones.Cantones = collection;
        return PartialView("~/Views/Shared/_CantonSelect.cshtml", direcciones);
    }

}