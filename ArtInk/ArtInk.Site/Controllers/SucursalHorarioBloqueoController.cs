using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class SucursalHorarioBloqueoController(IApiArtInkClient cliente) : Controller
{
    const string SUCCESSMESSAGEPARTIAL = "SuccessMessagePartial";
    const string ERRORMESSAGE = "ErrorMessage";
    const string ERRORMESSAGEPARTIAL = "ErrorMessagePartial";
    const string INDEXVIEW = "Index";
    const string BLOQUEOSPARTIALVIEW = "~/Views/SucursalHorarioBloqueo/_DetalleBloqueos.cshtml";
    const string CONTROLLERSUCURSALHORARIO = "SucursalHorario";

    public async Task<IActionResult> Gestionar(short? idSucursalHorario)
    {
        if (idSucursalHorario == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = "Debe seleccionar un horario de la sucursal para aplicar bloqueos";
            return RedirectToAction(INDEXVIEW, CONTROLLERSUCURSALHORARIO);
        }

        var url = string.Format(Constantes.GETSUCURSALHORARIO, idSucursalHorario.Value);
        var sucursalHorario = await cliente.ConsumirAPIAsync<SucursalHorarioResponseDto>(Constantes.GET, url);

        if (sucursalHorario == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEXVIEW, CONTROLLERSUCURSALHORARIO);
        }

        var sucursalHorarioBloqueo = new SucursalHorarioBloqueos()
        {
            IdSucursalHorario = idSucursalHorario.Value,
            Accion = 'A',
            SucursalHorario = sucursalHorario,
        };

        sucursalHorarioBloqueo.PrecargarBloqueos();

        return View(sucursalHorarioBloqueo);
    }

    [HttpPost]
    public IActionResult AgregarEliminarBloqueo(SucursalHorarioBloqueos sucursalHorarioBloqueos)
    {
        sucursalHorarioBloqueos.SetearHoras();

        if(sucursalHorarioBloqueos.Accion == 'E')
        {   
            sucursalHorarioBloqueos.EliminarBloqueo(sucursalHorarioBloqueos.IdBloqueo);
            TempData[SUCCESSMESSAGEPARTIAL] = $"Bloqueo eliminado correctamnete";

            return PartialView(BLOQUEOSPARTIALVIEW, sucursalHorarioBloqueos);
        } 

        if(sucursalHorarioBloqueos.HorariosIguales())
        {
            TempData[ERRORMESSAGEPARTIAL] = "Hora inicio y hora fin son iguales";
            return PartialView(BLOQUEOSPARTIALVIEW, sucursalHorarioBloqueos);
        }

        if(sucursalHorarioBloqueos.HorarioInicioMayorHorarioFin())
        {
            TempData[ERRORMESSAGEPARTIAL] = "Hora inicio es mayor a hora fin";
            return PartialView(BLOQUEOSPARTIALVIEW, sucursalHorarioBloqueos);
        }

        if(sucursalHorarioBloqueos.HorarioTraslapados())
        {
            TempData[ERRORMESSAGEPARTIAL] = "Horario de inicio y fin seleccionado se traslapa con uno existente";
            return PartialView(BLOQUEOSPARTIALVIEW, sucursalHorarioBloqueos);
        }

        sucursalHorarioBloqueos.AgregarBloqueo();
        TempData[SUCCESSMESSAGEPARTIAL] = $"Bloqueo agregado correctamnete";

        return PartialView(BLOQUEOSPARTIALVIEW, sucursalHorarioBloqueos);
    }

    [HttpPost]
    public async Task<IActionResult> Gestionar(SucursalHorarioBloqueos sucursalHorarioBloqueos)
    {
        var url = string.Format(Constantes.GETSUCURSALHORARIO, sucursalHorarioBloqueos.IdSucursalHorario);
        var sucursalHorario = await cliente.ConsumirAPIAsync<SucursalHorarioResponseDto>(Constantes.GET, url);

        if (sucursalHorario == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEXVIEW, CONTROLLERSUCURSALHORARIO);
        }

        sucursalHorarioBloqueos.SetearHoras();

        url = string.Format(Constantes.POSTSUCURSALHORARIOBLOQUEO, sucursalHorarioBloqueos.IdSucursalHorario);
        var sucursalHorarioBloqueo = await cliente.ConsumirAPIAsync<bool>(Constantes.POST, url, valoresConsumo: Serialization.Serialize(sucursalHorarioBloqueos.Bloqueos));
        if (sucursalHorarioBloqueo)
        {
            TempData["SuccessMessage"] = "Bloqueos guardados correctamente";
            return RedirectToAction(INDEXVIEW, CONTROLLERSUCURSALHORARIO);
        }

        TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
        return View(sucursalHorarioBloqueos);
    }
}