﻿using ArtInk.Site.Client;
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
        var horarios = await cliente.ConsumirAPIAsync<List<HorarioResponseDto>>(Constantes.GET, Constantes.GETALLHORARIOS);
        if (horarios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        horarios.Insert(0, new HorarioResponseDto() { Id = 0, NombreSelect = "Seleccione un horario." });

        sucursalSucursalHorario.Horarios = horarios;

        if (sucursalSucursalHorario.Accion == 'R')
        {
            sucursalSucursalHorario.HorariosSucursal = sucursalSucursalHorario.HorariosSucursal.Where(m => m.IdHorario != sucursalSucursalHorario.IdHorario).ToList();
            TempData["SuccessMessagePartial"] = "Horario removido de la lista preliminar";
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        if (sucursalSucursalHorario.HorariosSucursal.Where(m => m.IdHorario == sucursalSucursalHorario.IdHorario).Any())
        {
            TempData["ErrorMessagePartial"] = "Horario ya existe en lista preliminar";
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        var url = string.Format(Constantes.GETHORARIOBYID, sucursalSucursalHorario.IdHorario);
        var horario = await cliente.ConsumirAPIAsync<HorarioResponseDto>(Constantes.GET, url);
        if (horario == null)
        {
            TempData["ErrorMessagePartial"] = cliente.Error ? cliente.MensajeError : null;
            return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
        }

        sucursalSucursalHorario.HorariosSucursal.Add(new SucursalHorarioRequestDto()
        {
            IdHorario = sucursalSucursalHorario.IdHorario,
            Horario = horario
        });

        TempData["SuccessMessagePartial"] = "Horario agregado a lista preliminar";

        sucursalSucursalHorario.HorariosSucursal = sucursalSucursalHorario.HorariosSucursal.OrderBy(m => m.IdHorario).ToList();
        return PartialView(HORARIOSPARTIALVIEW, sucursalSucursalHorario);
    }

    public async Task<IActionResult> Gestionar(byte idSucursal)
    {
        if (idSucursal == 0)
        {
            TempData[ERRORMESSAGE] = "Asegurese de seleccionar una sucursal";
            return RedirectToAction(INDEX);
        }

        var url = string.Format(Constantes.GETHORARIOBYSUCURSAL, idSucursal);
        var sucursalHorarios = await cliente.ConsumirAPIAsync<IEnumerable<SucursalHorarioResponseDto>>(Constantes.GET, url);
        if (sucursalHorarios == null)
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

        var horarios = await cliente.ConsumirAPIAsync<List<HorarioResponseDto>>(Constantes.GET, Constantes.GETALLHORARIOS);
        if (horarios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }

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
        var horario = await cliente.ConsumirAPIAsync<bool?>(Constantes.POST, url, valoresConsumo: Serialization.Serialize(sucursalSucursalHorario.HorariosSucursal));
        if (horario != null)
        {
            TempData["SuccessMessage"] = "Horarios guardados correctamente";
            return RedirectToAction(INDEX);
        }

        var horarios = await cliente.ConsumirAPIAsync<List<HorarioResponseDto>>(Constantes.GET, Constantes.GETALLHORARIOS);
        if (horarios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEX);
        }
        horarios.Insert(0, new HorarioResponseDto() { Id = 0, NombreSelect = "Seleccione un horario." });
        sucursalSucursalHorario.Horarios = horarios;

        TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
        return View(sucursalSucursalHorario);
    }
}