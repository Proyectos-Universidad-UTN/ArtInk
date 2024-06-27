using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ArtInk.Site.Controllers
{
    public class DistritoController(IAPIArtInkClient distritoCliente) : Controller
    {
        public async Task<IActionResult> ObtenerDistritos(byte idCanton)
        {
            var url = string.Format(Constantes.GETALLDISTRITOSBYCANTON, idCanton);
            var collection = await distritoCliente.ConsumirAPIAsync<List<DistritoResponseDTO>>(Constantes.GET, url);
            collection.Insert(0, new DistritoResponseDTO() { Id = 0, Nombre = "Seleccione un distrito" });
            return PartialView("~/Views/Shared/_DistritoSelect.cshtml", collection);
        }

        public async Task<DistritoResponseDTO> ObtenerDistrito(byte id)
        {
            var url = string.Format(Constantes.GETALLDISTRITOS, id);
            var distrito = await distritoCliente.ConsumirAPIAsync<DistritoResponseDTO>(Constantes.GET, url);
            return distrito;
        }
    }
}
