using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace ArtInk.Site.Controllers
{
    public class ServicioController(IAPIArtInkClient cliente) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<ServicioResponseDTO>>(Constantes.GET, Constantes.GETALLSERVICIOS);
            return View(collection);
        }

        public async Task<IActionResult> Details(byte id)
        {
            var url = string.Format(Constantes.GETSERVICIOBYID, id);
            var collection = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.GET, url);

            return View(collection);
        }

        public async Task<IActionResult> Create()
        {
            var tipoServicio = await cliente.ConsumirAPIAsync<IEnumerable<TipoServicioResponseDTO>>(Constantes.GET, Constantes.GETALLTIPOSERVICIOS);
            var servicio = new ServicioRequestDTO()
            {
                TipoServicios = tipoServicio
            };
            return View(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicioRequestDTO servicio)
        {
            var tipoServicio = await cliente.ConsumirAPIAsync<IEnumerable<TipoServicioResponseDTO>>(Constantes.GET, Constantes.GETALLTIPOSERVICIOS);
            servicio.TipoServicios = tipoServicio;

            try
            {
                var resultado = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.POST, Constantes.POSTSERVICIO, valoresConsumo: Serialization.Serialize(servicio));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(servicio);
            }
        }
    }
}
