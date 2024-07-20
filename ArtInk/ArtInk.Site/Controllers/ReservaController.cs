using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ReservaController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";
    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ReservaResponseDto>>(Constantes.GET, Constantes.GETALLRESERVAS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }
        return View(collection);
    }

    public async Task<IActionResult> Details(int id)
    {
        var url = string.Format(Constantes.GETRESERVABYID, id);
        var collection = await cliente.ConsumirAPIAsync<ReservaResponseDto>(Constantes.GET, url);

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        return View(collection);
    }

        public async Task<IActionResult> Create()
    {
       var reserva = new ReservaRequestDto();
       return View(reserva);
    }



    [HttpPost]
    public async Task<IActionResult> Create(ReservaRequestDto reserva)
    {
      

        var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDto>(Constantes.POST, Constantes.POSTRESERVA, valoresConsumo: Serialization.Serialize(reserva));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(reserva);
        }

        TempData["SuccessMessage"] = "Reserva creada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var url = string.Format(Constantes.GETRESERVABYID, id);
        var reservaExisting = await cliente.ConsumirAPIAsync<ReservaResponseDto>(Constantes.GET, url);
        if (reservaExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var reserva = mapper.Map<ReservaRequestDto>(reservaExisting);

        return View(reserva);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ReservaRequestDto reserva)
    {
        var url = string.Format(Constantes.PUTRESERVA, reserva.Id);

        var resultado = await cliente.ConsumirAPIAsync<ReservaResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(reserva));

        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(reserva);
        }

        TempData["SuccessMessage"] = "Reserva actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }

}