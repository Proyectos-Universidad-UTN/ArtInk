﻿using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class DistritoController(IApiArtInkClient distritoCliente) : BaseArtInkController
{
    [HttpPost]
    public async Task<IActionResult> ObtenerDistritos(Direcciones direcciones)
    {
        var url = string.Format(Constantes.GETALLDISTRITOSBYCANTON, direcciones.IdCanton);
        var collection = await distritoCliente.ConsumirAPIAsync<List<DistritoResponseDto>>(Constantes.GET, url);
        collection.Insert(0, new DistritoResponseDto() { Id = 0, Nombre = "Seleccione un distrito" });
        direcciones.Distritos = collection;
        return PartialView("~/Views/Shared/_DistritoSelect.cshtml", direcciones);
    }
}