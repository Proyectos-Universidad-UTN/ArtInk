using ArtInk.Site.Client;
using ArtInk.Site.Common;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class SucursalController(IApiArtInkClient cliente, IMapper mapper, ICurrentUserAccessor currentUserAccessor) : BaseArtInkController()
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string SELECCIONEPROVINCIA = "Seleccione una provincia";
    const string ROLSINACCESO = "Rol no posee acceso";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }

        return View(collection);
    }

    public async Task<IActionResult> Details(byte id)
    {
        var url = string.Format(Constantes.GETSUCURSALBYID, id);
        var sucursal = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.GET, url);
        if (sucursal == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }

        return View(sucursal);
    }

    public async Task<IActionResult> Create()
    {
        try
        {
            if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
            {
                TempData[ERRORMESSAGE] = ROLSINACCESO;
                return RedirectToAction("Index", "Home");
            }

            var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
            provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });

            if (provincias == null) return RedirectToAction("Index", "Home");

            var sucursal = new SucursalRequestDto()
            {
                Provincias = provincias
            };
            return View(sucursal);
        }
        catch (Exception)
        {
            return RedirectToAction(nameof(Index));
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(SucursalRequestDto sucursal)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        if (provincias == null) return RedirectToAction(nameof(Index));

        provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });
        sucursal.Provincias = provincias;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return RedirectToAction(nameof(Index));
        }

        var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.POST, Constantes.POSTSUCURSAL, valoresConsumo: Serialization.Serialize(sucursal));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(sucursal);
        }

        TempData["SuccessMessage"] = "Sucursal creada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(byte id)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var url = string.Format(Constantes.GETSUCURSALBYID, id);
        var sucursalExisting = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.GET, url);
        if (sucursalExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });

        var sucursal = mapper.Map<SucursalRequestDto>(sucursalExisting);
        sucursal.Provincias = provincias;
        sucursal.IdDistrito = sucursalExisting.IdDistrito;
        sucursal.IdCanton = sucursalExisting.Distrito.IdCanton;
        sucursal.IdProvincia = sucursalExisting.Distrito.Canton.IdProvincia;

        return View(sucursal);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SucursalRequestDto sucursal)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var url = string.Format(Constantes.PUTSUCURSAL, sucursal.Id);
        var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        if (provincias == null) return RedirectToAction(nameof(Index));

        provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });
        sucursal.Provincias = provincias;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(sucursal);
        }

        var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(sucursal));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(sucursal);
        }

        TempData["SuccessMessage"] = "Sucursal actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }
}