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

public class SucursalFeriadoController(IApiArtInkClient cliente, IMapper mapper) : BaseArtInkController
{
    const string INDEX = "Index";
    const string SFSUCCESSMESSAGE = "SuccessMessage";
    const string SFERRORMESSAGE = "ErrorMessage";
    const string SFSUCCESSMESSAGEPARTIAL = "SuccessMessagePartial";
    const string SFERRORMESSAGEPARTIAL = "ErrorMessagePartial";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        collection.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });
        if (collection == null)
        {
            SetErrorMessage();
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

        var (falloEjecucion, feriados) = await ObtenerFeriados();
        if (falloEjecucion) return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);

        sucursalSucursalFeriado.Feriados = feriados;

        RemoveSucursalRequireModel();
        if (!ModelState.IsValid)
        {
            TempData[SFERRORMESSAGEPARTIAL] = "Formulario no cumple con valores requeridos";
            return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        }

        if (sucursalSucursalFeriado.Accion == 'R') sucursalSucursalFeriado.EliminarFeriado();

        if (sucursalSucursalFeriado.Accion == 'A')
        {
            var feriadodoSeleccionado = feriados.Single(m => m.Id == sucursalSucursalFeriado.IdFeriado);
            var feriadoSucursal = new SucursalFeriadoRequestDto()
            {
                IdFeriado = sucursalSucursalFeriado.IdFeriado,
                Fecha = DateOnly.FromDateTime(new DateTime(sucursalSucursalFeriado.Anno, (int)feriadodoSeleccionado.Mes, feriadodoSeleccionado.Dia, 0, 0, 0, DateTimeKind.Local)),
                Feriado = feriadodoSeleccionado,
                Anno = sucursalSucursalFeriado.Anno
            };

            sucursalSucursalFeriado.AgregarFeriado(feriadoSucursal);
        }

        var feriadosExistentesSucursal = feriados.Where(m => sucursalSucursalFeriado.FeriadosSucursal.Exists(x => x.IdFeriado == m.Id)).ToList();
        sucursalSucursalFeriado.Feriados = feriados.Except(feriadosExistentesSucursal).ToList();

        string mensajeProceso = sucursalSucursalFeriado.Accion == 'E' ? "eliminado de" : "agregado a";
        TempData[SFSUCCESSMESSAGEPARTIAL] = $"Feriado {mensajeProceso} lista preliminar";

        // if (sucursalSucursalFeriado.Accion == 'R')
        // {
        //     sucursalSucursalFeriado.FeriadosSucursal = sucursalSucursalFeriado.FeriadosSucursal.Where(m => m.IdFeriado != sucursalSucursalFeriado.IdFeriado).ToList();
        //     TempData[SFSUCCESSMESSAGEPARTIAL] = "Feriado removido de la lista preliminar";
        //     return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        // }

        // if (sucursalSucursalFeriado.FeriadosSucursal.Exists(m => m.IdFeriado == sucursalSucursalFeriado.IdFeriado))
        // {
        //     TempData[SFERRORMESSAGEPARTIAL] = "Feriado ya existe en lista preliminar";
        //     return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        // }

        // var url = string.Format(Constantes.GETFERIADOBYID, sucursalSucursalFeriado.IdFeriado);
        // var feriado = await cliente.ConsumirAPIAsync<FeriadoResponseDto>(Constantes.GET, url);
        // if (feriado == null)
        // {
        //     TempData[SFERRORMESSAGEPARTIAL] = cliente.Error ? cliente.MensajeError : null;
        //     return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
        // }

        

        // TempData[SFSUCCESSMESSAGEPARTIAL] = "Feriado agregado a lista preliminar";

        //sucursalSucursalFeriado.FeriadosSucursal = sucursalSucursalFeriado.FeriadosSucursal.OrderBy(m => m.Fecha).ToList();
        return PartialView(FERIADOPARTIALVIEW, sucursalSucursalFeriado);
    }

    public async Task<IActionResult> Gestionar(byte idSucursal, short anno)
    {
        if (idSucursal == 0 || anno == 0 || !ModelState.IsValid)
        {
            TempData[SFERRORMESSAGE] = "Asegurese de seleccionar una sucursal y un año";
            return RedirectToAction(INDEX);
        }

        var url = string.Format(Constantes.GETSUCURSALFERIADO, idSucursal, anno);
        var sucursalFeriados = await cliente.ConsumirAPIAsync<IEnumerable<SucursalFeriadoResponseDto>>(Constantes.GET, url);
        if (sucursalFeriados == null)
        {
            SetErrorMessage();
            return RedirectToAction(INDEX);
        }

        url = string.Format(Constantes.GETSUCURSALBYID, idSucursal);
        var sucursal = await cliente.ConsumirAPIAsync<SucursalResponseDto>(Constantes.GET, url);
        if (sucursal == null)
        {
            SetErrorMessage();
            return RedirectToAction(INDEX);
        }

        var (falloEjecucion, feriados) = await ObtenerFeriados();
        if (falloEjecucion) return RedirectToAction(INDEX);

        var sucursalSucursalFeriado = new SucursalSucursalFeriado()
        {
            Sucursal = sucursal,
            Anno = anno,
        };
        sucursalSucursalFeriado.CargarFeriados(mapper.Map<IEnumerable<SucursalFeriadoRequestDto>>(sucursalFeriados), feriados, anno);

        sucursalSucursalFeriado.Feriados = feriados;

        return View(sucursalSucursalFeriado);
    }

    [HttpPost]
    public async Task<ActionResult> Gestionar(SucursalSucursalFeriado sucursalSucursalFeriado)
    {
        var url = string.Format(Constantes.POSTSUCURSALFERIADO, sucursalSucursalFeriado.Sucursal.Id);
        var (falloEjecucion, feriados) = await ObtenerFeriados();
        if (falloEjecucion) return RedirectToAction(INDEX);
        
        sucursalSucursalFeriado.Feriados = feriados;

        RemoveSucursalRequireModel();
        if (!ModelState.IsValid)
        {
            TempData[SFSUCCESSMESSAGE] = "Formulario no cumple con valores requeridos";
            return View(sucursalSucursalFeriado);
        }

        var feriado = await cliente.ConsumirAPIAsync<bool?>(Constantes.POST, url, valoresConsumo: Serialization.Serialize(sucursalSucursalFeriado.FeriadosSucursal));
        if (feriado != null)
        {
            TempData["SuccessMessage"] = "Feriados guardados correctamente";
            return RedirectToAction(INDEX);
        }

        SetErrorMessage();
        return View(sucursalSucursalFeriado);
    }

    private async Task<(bool fallo, List<FeriadoResponseDto>)> ObtenerFeriados()
    {
        var feriados = await cliente.ConsumirAPIAsync<List<FeriadoResponseDto>>(Constantes.GET, Constantes.GETALLFERIADOS);
        if (feriados == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }

        feriados.Insert(0, new FeriadoResponseDto() { Id = 0, Nombre = "Seleccione un feriado" });
        return (false, feriados)!;
    }

    private void SetErrorMessage() => TempData[SFERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private void RemoveSucursalRequireModel()
    {
        ModelState.Remove("Sucursal.Id");
        ModelState.Remove("Sucursal.Nombre");
        ModelState.Remove("Sucursal.Distrito");
        ModelState.Remove("Sucursal.Descripcion");
        ModelState.Remove("Sucursal.CorreoElectronico");
    }
}