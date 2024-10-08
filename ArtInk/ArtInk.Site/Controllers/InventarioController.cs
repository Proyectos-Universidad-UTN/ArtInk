using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class InventarioController(IApiArtInkClient cliente, IMapper mapper) : BaseArtInkController
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string SUCURSALINVALIDA = "Debe ingresar una sucursal válida";

    public async Task<IActionResult> Index()
    {
        var (falloEjecucion, sucursales) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction("Index", "Home");

        var sucursalInventario = new SucursalInventario()
        {
            UrlAPI = cliente.BaseUrlAPI,
            Sucursales = sucursales
        };

        return View(sucursalInventario);
    }

    public async Task<IActionResult> Create()
    {
        var (falloEjecucion, sucursales) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var sucursalInventario = new InventarioRequestDto()
        {
            Sucursales = sucursales
        };
        return View(sucursalInventario);
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
            SetErrorMessage();
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
            SetErrorMessage();
            return RedirectToAction(nameof(Index));
        }

        var (falloEjecucion, sucursales) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion)
        {
            SetErrorMessage();
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
            SetErrorMessage();
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
            SetErrorMessage();
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
            SetErrorMessage();
            return RedirectToAction(nameof(Index));
        }

        TempData["SuccessMessage"] = "Inventario eliminado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> ObtenerInventarios(SucursalInventarioProducto sucursalInventarioProducto)
    {
        var url = String.Format(Constantes.GETINVENTARIOSBYSUCURSAL, sucursalInventarioProducto.IdSucursal);
        var inventarios = await cliente.ConsumirAPIAsync<List<InventarioResponseDto>>(Constantes.GET, url);
        inventarios.Insert(0, new InventarioResponseDto() { Id = 0, Nombre = "Seleccione un inventario" });
        sucursalInventarioProducto.Inventarios = inventarios;

        return PartialView("~/Views/Shared/_InventarioSelect.cshtml", sucursalInventarioProducto);
    }

    private IActionResult SetErrorMessage(string message)
    {
        TempData[ERRORMESSAGE] = message;
        return RedirectToAction("Index", "Home");
    }

    private void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private async Task<(bool fallo, List<SucursalResponseDto>)> ObtenerValoresInicialesSelect()
    {
        var sucursales = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        if (sucursales == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }
        sucursales.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });

        return (false, sucursales);
    }
}