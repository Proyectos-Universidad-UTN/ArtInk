using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class SucursalHorarioController (IAPIArtInkClient cliente, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<List<SucursalResponseDTO>>(Constantes.GET, Constantes.GETALLSUCURSALES);
            collection.Insert(0, new SucursalResponseDTO() { Id = 0, Nombre = "Seleccione una sucursal" });
            if (collection == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index", "Home");
            }

            var annos = new List<int>();
            for (int i = 2014; i <= DateTime.Now.Year + 2; i++) annos.Add(i);

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
            var horarios = await cliente.ConsumirAPIAsync<List<HorarioResponseDTO>>(Constantes.GET, Constantes.GETALLHORARIOS);
            if (horarios == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return PartialView("~/Views/SucursalHorario/_Horarios.cshtml", sucursalSucursalHorario);
            }

            horarios.Insert(0, new HorarioResponseDTO()
            {
                Id = 0,
                Dia = DiaSemana.SeleccioneUnDia, 
                HoraInicio = default,
                HoraFin = default
            });
            sucursalSucursalHorario.Horarios = horarios;

            if (sucursalSucursalHorario.Accion == 'R')
            {
                sucursalSucursalHorario.HorariosSucursal = sucursalSucursalHorario.HorariosSucursal.Where(m => m.IdHorario != sucursalSucursalHorario.IdHorario).ToList();
                TempData["SuccessMessagePartial"] = "Horario removido de la lista preliminar";
                return PartialView("~/Views/SucursalHorario/_Horarios.cshtml", sucursalSucursalHorario);
            }

            if (sucursalSucursalHorario.HorariosSucursal.Where(m => m.IdHorario == sucursalSucursalHorario.IdHorario).Count() > 0)
            {
                TempData["ErrorMessagePartial"] = "Horario ya existe en lista preliminar";
                return PartialView("~/Views/SucursalHorario/_Horarios.cshtml", sucursalSucursalHorario);
            }

            var url = string.Format(Constantes.GETHORARIOBYID, sucursalSucursalHorario.IdHorario);
            var horario = await cliente.ConsumirAPIAsync<HorarioResponseDTO>(Constantes.GET, url);
            if (horario == null)
            {
                TempData["ErrorMessagePartial"] = cliente.Error ? cliente.MensajeError : null;
                return PartialView("~/Views/SucursalHorario/_Horarioss.cshtml", sucursalSucursalHorario);
            }

            sucursalSucursalHorario.HorariosSucursal.Add(new SucursalHorarioRequestDTO()
            {
                IdHorario = sucursalSucursalHorario.IdHorario,
                Horario = horario
            });

            TempData["SuccessMessagePartial"] = "Horario agregado a lista preliminar";

            sucursalSucursalHorario.HorariosSucursal = sucursalSucursalHorario.HorariosSucursal.OrderBy(m => m.Horario).ToList();
            return PartialView("~/Views/SucursalHorario/_Horarios.cshtml", sucursalSucursalHorario);
        }

    }
}
