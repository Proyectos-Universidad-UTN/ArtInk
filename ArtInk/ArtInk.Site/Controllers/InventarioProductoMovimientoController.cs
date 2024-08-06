using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class InventarioProductoMovimientoController(IApiArtInkClient cliente) : BaseArtInkController
{
    const string ERRORMESSAGE = "ErrorMessage";

    public IActionResult Entrada(long id)
    {
        if (!ModelState.IsValid || id == 0)
        {
            TempData[ERRORMESSAGE] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        var inventarioProducto = new InventarioProductoMovimientoRequestDto(TipoMovimientoInventario.Entrada);
        inventarioProducto.IdInventarioProducto = id;

        return View("Gestion", inventarioProducto);
    }

    public IActionResult Salida(long id)
    {
        if (!ModelState.IsValid || id == 0)
        {
            TempData[ERRORMESSAGE] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        var inventarioProducto = new InventarioProductoMovimientoRequestDto(TipoMovimientoInventario.Salida);
        inventarioProducto.IdInventarioProducto = id;

        return View("Gestion", inventarioProducto);
    }

    [HttpPost]
    public async Task<IActionResult> Gestion(InventarioProductoMovimientoRequestDto inventarioProductoMovimientoRequest)
    {
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(inventarioProductoMovimientoRequest);
        }

        var resultado = await cliente.ConsumirAPIAsync<bool>(Constantes.POST, Constantes.POSTINVENTARIOPRODUCTOMOVIMIENTO, valoresConsumo: Serialization.Serialize(inventarioProductoMovimientoRequest));
        if (!resultado)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(inventarioProductoMovimientoRequest);
        }

        TempData["SuccessMessage"] = "Movimiento de inventario creado correctamente.";

        return RedirectToAction("Index", "InventarioProducto");
    }
}