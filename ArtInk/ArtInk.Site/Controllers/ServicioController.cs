using ArtInk.Site.Client;
using ArtInk.Site.Common;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ServicioController(IApiArtInkClient cliente, IMapper mapper, ICurrentUserAccessor currentUserAccessor) : BaseArtInkController
{
    const string INDEX = "Index";
    const string ERRORMESSAGE = "ErrorMessage";
    const string ROLSINACCESO = "Rol no posee acceso";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX, "Home");
        }

        return View(collection);
    }

    public async Task<IActionResult> Details(byte id)
    {
        var url = string.Format(Constantes.GETSERVICIOBYID, id);
        var collection = await cliente.ConsumirAPIAsync<ServicioResponseDto>(Constantes.GET, url);
        if (collection == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }

        return View(collection);
    }

    public async Task<IActionResult> Create()
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var tipoServicio = await cliente.ConsumirAPIAsync<IEnumerable<TipoServicioResponseDto>>(Constantes.GET, Constantes.GETALLTIPOSERVICIOS);
        if (tipoServicio == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }

        var servicio = new ServicioRequestDto()
        {
            TipoServicios = tipoServicio
        };
        return View(servicio);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ServicioRequestDto servicio)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var tipoServicio = await cliente.ConsumirAPIAsync<IEnumerable<TipoServicioResponseDto>>(Constantes.GET, Constantes.GETALLTIPOSERVICIOS);
        if (tipoServicio == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }

        servicio.TipoServicios = tipoServicio;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(servicio);
        }

        var resultado = await cliente.ConsumirAPIAsync<ServicioResponseDto>(Constantes.POST, Constantes.POSTSERVICIO, valoresConsumo: Serialization.Serialize(servicio));

        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(servicio);
        }

        TempData["SuccessMessage"] = "Servicio creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(byte id)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var url = string.Format(Constantes.GETSERVICIOBYID, id);
        var servicioExisting = await cliente.ConsumirAPIAsync<ServicioResponseDto>(Constantes.GET, url);
        if (servicioExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var servicios = await cliente.ConsumirAPIAsync<List<TipoServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        servicios.Insert(0, new TipoServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });

        var servicio = mapper.Map<ServicioRequestDto>(servicioExisting);
        servicio.TipoServicios = servicios;

        return View(servicio);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ServicioRequestDto servicio)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var url = string.Format(Constantes.PUTSERVICIO, servicio.Id);
        var servicios = await cliente.ConsumirAPIAsync<List<TipoServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        servicios.Insert(0, new TipoServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });
        servicio.TipoServicios = servicios;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(servicio);
        }

        var resultado = await cliente.ConsumirAPIAsync<ServicioResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(servicio));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(servicio);
        }

        TempData["SuccessMessage"] = "Servicio actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }
}