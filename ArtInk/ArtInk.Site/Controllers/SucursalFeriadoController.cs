using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class SucursalFeriadoController(IAPIArtInkClient cliente) : Controller
{
    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<List<SucursalResponseDTO>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        collection.Insert(0, new SucursalResponseDTO() { Id = 0, Nombre = "Seleccione una sucursal" });
        if (collection == null)
        {
            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }

        var annos = new List<int>();
        for (int i = 2014; i <= DateTime.Now.Year; i++) annos.Add(i);

        var sucursalFeriados = new SucursalFeriados()
        {
            UrlAPI = cliente.BaseUrlAPI,
            Annos = annos.OrderByDescending(x => x).ToList(),
            Sucursales = collection
        };

        return View(sucursalFeriados);
    }

    public async Task<IActionResult> Gestionar(byte idSucursal, short anno)
    {
        if (idSucursal == 0 || anno == 0)
        {
            TempData["ErrorMessage"] = "Asegurese de seleccionar una sucursal y un año";
            return RedirectToAction("Index");
        }

        var url = string.Format(Constantes.GETSUCURSALBYID, idSucursal);
        var sucursal = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.GET, url);
        if (sucursal == null)
        {
            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index");
        }

        var feriados = await cliente.ConsumirAPIAsync<IEnumerable<FeriadoResponseDTO>>(Constantes.GET, Constantes.GETALLFERIADOS);
        if (feriados == null)
        {
            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index");
        }

        var sucursalSucursalFeriado = new SucursalSucursalFeriado()
        {
            Sucursal = sucursal
        };
        sucursalSucursalFeriado.CargarFeriados(feriados, anno);

        return View(sucursalSucursalFeriado);
    }
}