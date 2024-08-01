using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class SucursalHorarioBloqueoController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string INDEXVIEW = "Index";
    const string CONTROLLERSUCURSALHORARIO = "SucursalHorario";

    public async Task<IActionResult> Gestionar(short? idSucursalHorario)
    {
        if (idSucursalHorario == null)
        {
            TempData[ERRORMESSAGE] = "Debe seleccionar un horario de la sucursal para aplicar bloqueos";
            return RedirectToAction(INDEXVIEW, CONTROLLERSUCURSALHORARIO);
        }

        var url = string.Format(Constantes.GETSUCURSALHORARIO, idSucursalHorario.Value);
        var sucursalHorario = await cliente.ConsumirAPIAsync<SucursalHorarioResponseDto>(Constantes.GET, url);

        if (sucursalHorario == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEXVIEW, CONTROLLERSUCURSALHORARIO);
        }

        var sucursalHorarioBloqueo = new SucursalHorarioBloqueos()
        {
            Accion = 'A',
            SucursalHorario = sucursalHorario,
        };

        sucursalHorarioBloqueo.PrecargarBloqueos();

        return View(sucursalHorarioBloqueo);
    }
}