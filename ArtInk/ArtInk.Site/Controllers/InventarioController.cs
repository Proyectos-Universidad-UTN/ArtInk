using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class InventarioController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string SUCURSALINVALIDA = "Debe ingresar una sucursal válida";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        collection.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }

        var sucursalFeriado = new SucursalInventario()
        {
            UrlAPI = cliente.BaseUrlAPI,
            Sucursales = collection
        };

        return View(sucursalFeriado);
    }

    public async Task<IActionResult> Create()
    {
        var (falloEjecucion, sucursales) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var inventario = new InventarioRequestDto()
        {
            Sucursales = sucursales
        };
        return View(inventario);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InventarioRequestDto inventario)
    {
        var (falloEjecucion, sucursales) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        inventario.Sucursales = sucursales;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(inventario);
        }

        string url = string.Format(Constantes.POSTINVENTARIO, inventario.IdSucursal);
        var resultado = await cliente.ConsumirAPIAsync<InventarioResponseDto>(Constantes.POST, url, valoresConsumo: Serialization.Serialize(inventario));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(inventario);
        }

        TempData["SuccessMessage"] = "Inventario creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(short id)
    {
        var url = string.Format(Constantes.GETINVENTARIOBYID, id);
        var inventarioExisting = await cliente.ConsumirAPIAsync<InventarioResponseDto>(Constantes.GET, url);
        if (inventarioExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var (falloEjecucion, sucursales) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var producto = mapper.Map<InventarioRequestDto>(inventarioExisting);
        producto.Sucursales = sucursales;

        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(InventarioRequestDto inventario)
    {
        var url = string.Format(Constantes.PUTINVENTARIO, inventario.IdSucursal, inventario.Id);

        var (falloEjecucion, sucursales) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        inventario.Sucursales = sucursales;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(inventario);
        }

        var resultado = await cliente.ConsumirAPIAsync<InventarioResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(inventario));

        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(inventario);
        }

        TempData["SuccessMessage"] = "Inventario actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Delete(short id)
    {
        var url = string.Format(Constantes.DELETEINVENTARIO, id);

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return RedirectToAction(nameof(Index));
        }


        var resultado = await cliente.ConsumirAPIAsync<bool>(Constantes.DELETE, url);

        if (!resultado)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = "Inventario eliminado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    private IActionResult SetErrorMessage(string message)
    {
        TempData[ERRORMESSAGE] = message;
        return RedirectToAction("Index", "Home");
    }

    private async Task<(bool fallo, List<SucursalResponseDto>)> ObtenerValoresInicialesSelect()
    {
        var sucursales = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        if (sucursales == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null)!;
        }
        sucursales.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });

        return (false, sucursales);
    }
}