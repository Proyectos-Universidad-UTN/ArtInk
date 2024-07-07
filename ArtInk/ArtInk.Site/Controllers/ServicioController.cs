using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace ArtInk.Site.Controllers
{
    public class ServicioController(IAPIArtInkClient cliente, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<ServicioResponseDTO>>(Constantes.GET, Constantes.GETALLSERVICIOS);
            if (collection == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index", "Home");
            }

            return View(collection);
        }

        public async Task<IActionResult> Details(byte id)
        {
            var url = string.Format(Constantes.GETSERVICIOBYID, id);
            var collection = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.GET, url);
            if (collection == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index");
            }

            return View(collection);
        }

        public async Task<IActionResult> Create()
        {
            var tipoServicio = await cliente.ConsumirAPIAsync<IEnumerable<TipoServicioResponseDTO>>(Constantes.GET, Constantes.GETALLTIPOSERVICIOS);
            if (tipoServicio == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index");
            }

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
            if (tipoServicio == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index");
            }

            servicio.TipoServicios = tipoServicio;

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return View(servicio);
            }

            var resultado = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.POST, Constantes.POSTSERVICIO, valoresConsumo: Serialization.Serialize(servicio));

            if (resultado == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return View(servicio);
            }
            
            TempData["SuccessMessage"] = "Servicio creado correctamente.";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(byte id)
        {
            var url = string.Format(Constantes.GETSERVICIOBYID, id);
            var servicioExisting = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.GET, url);
            if (servicioExisting == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            var servicios = await cliente.ConsumirAPIAsync<List<TipoServicioResponseDTO>>(Constantes.GET, Constantes.GETALLSERVICIOS);
            if (servicios == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            servicios.Insert(0, new TipoServicioResponseDTO() { Id = 0, Nombre = "Seleccione un servicio" });

            var servicio = mapper.Map<ServicioRequestDTO>(servicioExisting);
            servicio.TipoServicios = servicios;

            return View(servicio);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServicioRequestDTO servicio)
        {
            var url = string.Format(Constantes.PUTSERVICIO, servicio.Id);
            var servicios = await cliente.ConsumirAPIAsync<List<TipoServicioResponseDTO>>(Constantes.GET, Constantes.GETALLSERVICIOS);
            if (servicios == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            servicios.Insert(0, new TipoServicioResponseDTO() { Id = 0, Nombre = "Seleccione un servicio" });
            servicio.TipoServicios = servicios;

            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return View(servicio);
            }

            var resultado = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(servicio));
            if (resultado == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return View(servicio);
            }

            TempData["SuccessMessage"] = "Servicio actualizado correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}
