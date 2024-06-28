using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArtInk.Site.Controllers
{
    public class DistritoController(IAPIArtInkClient distritoCliente) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ObtenerDistritos(Direcciones direcciones)
        {
            var url = string.Format(Constantes.GETALLDISTRITOSBYCANTON, direcciones.IdCanton);
            var collection = await distritoCliente.ConsumirAPIAsync<List<DistritoResponseDTO>>(Constantes.GET, url);
            collection.Insert(0, new DistritoResponseDTO() { Id = 0, Nombre = "Seleccione un distrito" });
            direcciones.Distritos = collection;
            return PartialView("~/Views/Shared/_DistritoSelect.cshtml", direcciones);
        }

        public async Task<DistritoResponseDTO> ObtenerDistrito(byte id)
        {
            var url = string.Format(Constantes.GETALLDISTRITOS, id);
            var distrito = await distritoCliente.ConsumirAPIAsync<DistritoResponseDTO>(Constantes.GET, url);
            return distrito;
        }
    }
}
