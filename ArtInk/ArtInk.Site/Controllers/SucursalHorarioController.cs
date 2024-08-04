using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ArtInk.Utils;

namespace ArtInk.Site.Controllers;

public class SucursalHorarioController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string INDEX = "Index";
    const string SUCCESSMESSAGE = "SuccessMessage";
    const string ERRORMESSAGE = "ErrorMessage";
    const string SUCCESSMESSAGEPARTIAL = "SuccessMessagePartial";

    const string ERRORMESSAGEPARTIAL = "ErrorMessagePartial";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        collection.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });
        if (collection == null)
        {
            SetErrorMessage();
            return RedirectToAction(INDEX, "Home");
        }

        var sucursalHorarios = new SucursalHorarios()
        {
            UrlAPI = cliente.BaseUrlAPI,
            Sucursales = collection
        };

        return View(sucursalHorarios);
    }

    [HttpPost]
    public async Task<IActionResult> AgregarEliminarHorarioSucursal(SucursalSucursalHorario sucursalSucursalHorario)
    {
        const string HORARIOSPARTIALVIEW = "~/Views/SucursalHorario/_Horarios.cshtml";

        var (falloEjecucion, horarios) = await ObtenerHorarios();
        if (falloEjecucion) return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);

        horarios.Insert(0, new HorarioResponseDto() { Id = 0, NombreSelect = "Seleccione un horario." });
        sucursalSucursalHorario.Horarios = horarios;

        RemoveSucursalRequireModel();
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGEPARTIAL] = "Formulario no cumple con valores requeridos";
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        if (sucursalSucursalHorario.Accion == 'R')
        {
            sucursalSucursalHorario.HorariosSucursal = sucursalSucursalHorario.HorariosSucursal.Where(m => m.IdHorario != sucursalSucursalHorario.IdHorario).ToList();
            TempData[SUCCESSMESSAGEPARTIAL] = "Horario removido de la lista preliminar";
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        if (sucursalSucursalHorario.HorariosSucursal.Exists(m => m.IdHorario == sucursalSucursalHorario.IdHorario))
        {
            TempData[ERRORMESSAGEPARTIAL] = "Horario ya existe en lista preliminar";
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        var url = string.Format(Constantes.GETHORARIOBYID, sucursalSucursalHorario.IdHorario);
        var horario = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.GET, url);
        if (horario == null)
        {
            TempData[ERRORMESSAGEPARTIAL] = cliente.Error ? cliente.MensajeError : null;
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        sucursalSucursalHorario.HorariosSucursal.Add(new SucursalHorarioRequestDto()
        {
            IdHorario = sucursalSucursalHorario.IdHorario,
            Horario = horario
        });

        TempData[SUCCESSMESSAGEPARTIAL] = "Horario agregado a lista preliminar";

        sucursalSucursalHorario.HorariosSucursal = sucursalSucursalHorario.HorariosSucursal.OrderBy(m => m.IdHorario).ToList();
        return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
    }

    public async Task<IActionResult> Gestionar(byte idSucursal)
    {
        if (idSucursal == 0 || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = "Asegurese de seleccionar una sucursal";
            return RedirectToAction(INDEX);
        }

        var url = string.Format(Constantes.GETHORARIOBYSUCURSAL, idSucursal);
        var sucursalHorarios = await cliente.ConsumirAPIAsync<IEnumerable<SucursalHorarioResponseDto>>(Constantes.GET, url);
        if (sucursalHorarios == null)
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

        var (falloEjecucion, horarios) = await ObtenerHorarios();
        if (falloEjecucion) return RedirectToAction(INDEX);

        var sucursalSucursalHorario = new SucursalSucursalHorario()
        {
            Sucursal = sucursal,
        };
        sucursalSucursalHorario.CargarHorarios(mapper.Map<IEnumerable<SucursalHorarioRequestDto>>(sucursalHorarios), horarios);

        horarios.Insert(0, new HorarioResponseDto() { Id = 0, NombreSelect = "Seleccione un horario." });
        sucursalSucursalHorario.Horarios = horarios;

        return View(sucursalSucursalHorario);
    }

    [HttpPost]
    public async Task<ActionResult> Gestionar(SucursalSucursalHorario sucursalSucursalHorario)
    {
        var url = string.Format(Constantes.POSTSUCURSALHORARIO, sucursalSucursalHorario.Sucursal.Id);
        var (falloEjecucion, horarios) = await ObtenerHorarios();
        if (falloEjecucion) return RedirectToAction(INDEX);
        
        horarios.Insert(0, new HorarioResponseDto() { Id = 0, NombreSelect = "Seleccione un horario." });
        sucursalSucursalHorario.Horarios = horarios;

        RemoveSucursalRequireModel();
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = "Formulario no cumple con valores requeridos";
            return View(sucursalSucursalHorario);
        }

        var horario = await cliente.ConsumirAPIAsync<bool?>(Constantes.POST, url, valoresConsumo: Serialization.Serialize(sucursalSucursalHorario.HorariosSucursal));
        if (horario != null)
        {
            TempData[SUCCESSMESSAGE] = "Horarios guardados correctamente";
            return RedirectToAction(INDEX);
        }

        SetErrorMessage();
        return View(sucursalSucursalHorario);
    }

    private async Task<(bool fallo, List<HorarioResponseDto>)> ObtenerHorarios()
    {
        var horarios = await cliente.ConsumirAPIAsync<List<HorarioResponseDto>>(Constantes.GET, Constantes.GETALLHORARIOS);
        if (horarios == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }

        return (false, horarios);
    }

    private void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private void RemoveSucursalRequireModel()
    {
        ModelState.Remove("Sucursal.Id");
        ModelState.Remove("Sucursal.Nombre");
        ModelState.Remove("Sucursal.Distrito");
        ModelState.Remove("Sucursal.Descripcion");
        ModelState.Remove("Sucursal.CorreoElectronico");
    }
}