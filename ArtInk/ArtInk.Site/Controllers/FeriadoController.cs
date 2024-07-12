using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class FeriadoController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<FeriadoResponseDto>>(Constantes.GET, Constantes.GETALLFERIADOS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }
        return View(collection);
    }

    public IActionResult Create()
    {
        return View(new FeriadoRequestDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(FeriadoRequestDto feriado)
    {
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(feriado);
        }

        var resultado = await cliente.ConsumirAPIAsync<FeriadoResponseDto>(Constantes.POST, Constantes.POSTFERIADO, valoresConsumo: Serialization.Serialize(feriado));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(feriado);
        }

        TempData["SuccessMessage"] = "Feriado creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(byte id)
    {
        var url = string.Format(Constantes.GETFERIADOBYID, id);
        var feriadoExisting = await cliente.ConsumirAPIAsync<FeriadoResponseDto>(Constantes.GET, url);
        if (feriadoExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var feriado = mapper.Map<FeriadoRequestDto>(feriadoExisting);

        return View(feriado);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(FeriadoRequestDto feriado)
    {
        var url = string.Format(Constantes.PUTFERIADO, feriado.Id);

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(feriado);
        }

        var resultado = await cliente.ConsumirAPIAsync<FeriadoResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(feriado));

        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(feriado);
        }

        TempData["SuccessMessage"] = "Feriado actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Delete(byte id)
    {
        var url = string.Format(Constantes.DELETEFERIADO, id);

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

        TempData["SuccessMessage"] = "Feriado eliminado correctamente.";

        return RedirectToAction(nameof(Index));
    }
}