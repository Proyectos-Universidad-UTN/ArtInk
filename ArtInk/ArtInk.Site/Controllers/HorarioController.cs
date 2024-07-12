using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class HorarioController(IAPIArtInkClient cliente, IMapper mapper) : Controller
{
    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<HorarioResponseDto>>(Constantes.GET, Constantes.GETALLHORARIOS);
        if (collection == null)
        {
            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
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
        var resultado = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.POST, Constantes.POSTHORARIO, valoresConsumo: Serialization.Serialize(horario));
        if (resultado == null)
        {
            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
            return View(horario);
        }

        TempData["SuccessMessage"] = "Horario creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(short id)
    {
        var url = string.Format(Constantes.GETHORARIOBYID, id);
        var horarioExisting = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.GET, url);
        if (horarioExisting == null)
        {
            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var horario = mapper.Map<HorarioRequestDto>(horarioExisting);

        return View(horario);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(HorarioRequestDto horario)
    {
        var url = string.Format(Constantes.PUTHORARIO, horario.Id);

        var resultado = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(horario));

        if (resultado == null)
        {
            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
            return View(horario);
        }

        TempData["SuccessMessage"] = "Horario actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }
}