using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class HorarioController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<HorarioResponseDto>>(Constantes.GET, Constantes.GETALLHORARIOS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }
        return View(collection);
    }

    public IActionResult Create()
    {
        return View(new HorarioRequestDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(HorarioRequestDto horario)
    {
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(horario);
        }
        
        var resultado = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.POST, Constantes.POSTHORARIO, valoresConsumo: Serialization.Serialize(horario));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(horario);
        }

        TempData["SuccessMessage"] = "Horario creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(short id)
    {
        var url = string.Format(Constantes.GETHORARIOBYID, id);
        var horarioExisting = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.GET, url);
        if (horarioExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var horario = mapper.Map<HorarioRequestDto>(horarioExisting);

        return View(horario);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(HorarioRequestDto horario)
    {
        var url = string.Format(Constantes.PUTHORARIO, horario.Id);

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(horario);
        }

        var resultado = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(horario));

        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(horario);
        }

        TempData["SuccessMessage"] = "Horario actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }
}