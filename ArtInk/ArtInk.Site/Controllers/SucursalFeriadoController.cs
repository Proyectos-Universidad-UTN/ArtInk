using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class SucursalFeriadoController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string INDEX = "Index";
    const string ERRORMESSAGE = "ErrorMessage";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        collection.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX, "Home");
        }

        var annos = new List<int>();
        for (int i = 2014; i <= DateTime.Now.Year + 2; i++) annos.Add(i);

        var sucursalFeriados = new SucursalFeriados()
        {
            UrlAPI = cliente.BaseUrlAPI,
            Annos = annos.OrderByDescending(x => x).ToList(),
            Sucursales = collection
        };

        return View(sucursalFeriados);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarEliminarFeriadoSucursal(SucursalSucursalFeriado sucursalSucursalFeriado)
    {
        const string FERIADOPARTIALVIEW = "~/Views/SucursalFeriado/_Feriados.cshtml";
        var feriados = await cliente.ConsumirAPIAsync<List<FeriadoResponseDto>>(Constantes.GET, Constantes.GETALLFERIADOS);
        if (feriados == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        }

        feriados.Insert(0, new FeriadoResponseDto() { Id = 0, Nombre = "Seleccione un feriado" });
        sucursalSucursalFeriado.Feriados = feriados;

        if (!ModelState.IsValid)
        {
            TempData["SuccessMessagePartial"] = "Formulario no cumple con valores requeridos";
            return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        }

        if (sucursalSucursalFeriado.Accion == 'R')
        {
            sucursalSucursalFeriado.FeriadosSucursal = sucursalSucursalFeriado.FeriadosSucursal.Where(m => m.IdFeriado != sucursalSucursalFeriado.IdFeriado).ToList();
            TempData["SuccessMessagePartial"] = "Feriado removido de la lista preliminar";
            return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        }

        if (sucursalSucursalFeriado.FeriadosSucursal.Exists(m => m.IdFeriado == sucursalSucursalFeriado.IdFeriado))
        {
            TempData["ErrorMessagePartial"] = "Feriado ya existe en lista preliminar";
            return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        }

        var url = string.Format(Constantes.GETFERIADOBYID, sucursalSucursalFeriado.IdFeriado);
        var feriado = await cliente.ConsumirAPIAsync<FeriadoResponseDto>(Constantes.GET, url);
        if (feriado == null)
        {
            TempData["ErrorMessagePartial"] = cliente.Error ? cliente.MensajeError : null;
            return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        }

        sucursalSucursalFeriado.FeriadosSucursal.Add(new SucursalFeriadoRequestDto()
        {
            IdFeriado = sucursalSucursalFeriado.IdFeriado,
            Fecha = DateOnly.FromDateTime(new DateTime(sucursalSucursalFeriado.Anno, (int)feriado.Mes, feriado.Dia, 0, 0, 0, DateTimeKind.Local)),
            Feriado = feriado,
            Anno = sucursalSucursalFeriado.Anno
        });

        TempData["SuccessMessagePartial"] = "Feriado agregado a lista preliminar";

        sucursalSucursalFeriado.FeriadosSucursal = sucursalSucursalFeriado.FeriadosSucursal.OrderBy(m => m.Fecha).ToList();
        return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
    }

    public async Task<IActionResult> Gestionar(byte idSucursal, short anno)
    {
        if (idSucursal == 0 || anno == 0 || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = "Asegurese de seleccionar una sucursal y un año";
            return RedirectToAction(INDEX);
        }

        var url = string.Format(Constantes.GETSUCURSALFERIADO, idSucursal, anno);
        var sucursalFeriados = await cliente.ConsumirAPIAsync<IEnumerable<SucursalFeriadoResponseDto>>(Constantes.GET, url);
        if (sucursalFeriados == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }

        url = string.Format(Constantes.GETSUCURSALBYID, idSucursal);
        var sucursal = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.GET, url);
        if (sucursal == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }

        var feriados = await cliente.ConsumirAPIAsync<List<FeriadoResponseDto>>(Constantes.GET, Constantes.GETALLFERIADOS);
        if (feriados == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }

        var sucursalSucursalFeriado = new SucursalSucursalFeriado()
        {
            Sucursal = sucursal,
            Anno = anno,
        };
        sucursalSucursalFeriado.CargarFeriados(mapper.Map<IEnumerable<SucursalFeriadoRequestDto>>(sucursalFeriados), feriados, anno);

        feriados.Insert(0, new FeriadoResponseDto() { Id = 0, Nombre = "Seleccione un feriado" });
        sucursalSucursalFeriado.Feriados = feriados;

        return View(sucursalSucursalFeriado);
    }

    [HttpPost]
    public async Task<ActionResult> Gestionar(SucursalSucursalFeriado sucursalSucursalFeriado)
    {
        var url = string.Format(Constantes.POSTSUCURSALFERIADO, sucursalSucursalFeriado.Sucursal.Id);
        var feriado = await cliente.ConsumirAPIAsync<bool?>(Constantes.POST, url, valoresConsumo: Serialization.Serialize(sucursalSucursalFeriado.FeriadosSucursal));
        if (feriado != null)
        {
            TempData["SuccessMessage"] = "Feriados guardados correctamente";
            return RedirectToAction(INDEX);
        }

        var feriados = await cliente.ConsumirAPIAsync<List<FeriadoResponseDto>>(Constantes.GET, Constantes.GETALLFERIADOS);
        if (feriados == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }
        feriados.Insert(0, new FeriadoResponseDto() { Id = 0, Nombre = "Seleccione un feriado" });
        sucursalSucursalFeriado.Feriados = feriados;

        if (!ModelState.IsValid)
        {
            TempData["SuccessMessagePartial"] = "Formulario no cumple con valores requeridos";
            return View(sucursalSucursalFeriado);
        }

        TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
        return View(sucursalSucursalFeriado);
    }
}