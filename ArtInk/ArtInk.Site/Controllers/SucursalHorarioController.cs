using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request.Misc;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ArtInk.Utils;

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

        public async Task<IActionResult> Gestionar(byte idSucursal)
        {
            if (idSucursal == 0 )
            {
                TempData["ErrorMessage"] = "Asegurese de seleccionar una sucursal";
                return RedirectToAction("Index");
            }

            var url = string.Format(Constantes.GETSUCURSALHORARIO, idSucursal);
            var sucursalHorarios = await cliente.ConsumirAPIAsync<IEnumerable<SucursalHorarioResponseDTO>>(Constantes.GET, url);
            if (sucursalHorarios == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index");
            }

            url = string.Format(Constantes.GETSUCURSALBYID, idSucursal);
            var sucursal = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.GET, url);
            if (sucursal == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index");
            }

            var horarios = await cliente.ConsumirAPIAsync<List<HorarioResponseDTO>>(Constantes.GET, Constantes.GETALLHORARIOS);
            if (horarios == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index");
            }

            var sucursalSucursalHorario = new SucursalSucursalHorario()
            {
                Sucursal = sucursal,
            };
            sucursalSucursalHorario.CargarHorarios(mapper.Map<IEnumerable<SucursalHorarioRequestDTO>>(sucursalHorarios), horarios);

            horarios.Insert(0, new HorarioResponseDTO() { Id = 0, Dia=  DiaSemana.SeleccioneUnDia });
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
                return RedirectToAction("Index");
            }

            var horarios = await cliente.ConsumirAPIAsync<List<HorarioResponseDTO>>(Constantes.GET, Constantes.GETALLHORARIOS);
            if (horarios == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index");
            }
            //horarios.Insert(0, new HorarioResponseDTO() { Id = 0, Dia = DiaSemana.SeleccioneUnDia });
            sucursalSucursalHorario.Horarios = horarios;

            TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
            return View(sucursalSucursalHorario);
        }
    }
}
