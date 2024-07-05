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

        public async Task<IActionResult> Edit(byte id)
        {
            try
            {
                var url = string.Format(Constantes.GETSERVICIOBYID, id);
                var servicioExisting = await cliente.ConsumirAPIAsync<ServicioResponseDTO>(Constantes.GET, url);
                if (servicioExisting == null) return RedirectToAction(nameof(Index));

                var servicios = await cliente.ConsumirAPIAsync<List<TipoServicioResponseDTO>>(Constantes.GET, Constantes.GETALLSERVICIOS);
                servicios.Insert(0, new TipoServicioResponseDTO() { Id = 0, Nombre = "Seleccione un servicio" });

                var servicio = mapper.Map<ServicioRequestDTO>(servicioExisting);
                servicio.TipoServicios = servicios;

                return View(servicio);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServicioRequestDTO servicio)
        {
            try
            {
                var url = string.Format(Constantes.PUTSERVICIO, servicio.Id);
                var servicios = await cliente.ConsumirAPIAsync<List<TipoServicioResponseDTO>>(Constantes.GET, Constantes.GETALLSERVICIOS);
                if (servicios == null) return RedirectToAction(nameof(Index));

                servicios.Insert(0, new TipoServicioResponseDTO() { Id = 0, Nombre = "Seleccione un servicio" });
                servicio.TipoServicios = servicios;

                if (!ModelState.IsValid) return View(servicio);

                var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(servicio));
                if (resultado == null) return View(servicio);

                TempData["SuccessMessage"] = "Servicio actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
