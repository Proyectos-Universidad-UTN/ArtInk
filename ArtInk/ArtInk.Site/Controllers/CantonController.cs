using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArtInk.Site.Controllers
{
    public class CantonController(IAPIArtInkClient cantonCliente) : Controller
    {
        public async Task<IActionResult> ObtenerCantones(byte idProvincia)
        {
            var url = string.Format(Constantes.GETALLCANTONESBYPROVINCIA, idProvincia);
            var collection = await cantonCliente.ConsumirAPIAsync<List<CantonResponseDTO>>(Constantes.GET, url);
            collection.Insert(0, new CantonResponseDTO() { Id = 0, Nombre = "Seleccione un cantón" });
            return PartialView("~/Views/Shared/_CantonSelect.cshtml", collection);
        }

        public async Task<CantonResponseDTO> ObtenerCanton(byte id)
        {
            var url = string.Format(Constantes.GETCANTONBYID, id);
            var canton = await cantonCliente.ConsumirAPIAsync<CantonResponseDTO>(Constantes.GET, url);
            return canton;
        }
    }
}