using ArtInk.Site.Client;
using ArtInk.Site.Common;
using ArtInk.Site.Configuration;
using ArtInk.Site.Models;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ReservaController(IApiArtInkClient cliente, IMapper mapper, ICurrentUserAccessor currentUserAccessor) : BaseArtInkController
{
    const string INDEX = "Index";
    const string SUCCESSMESSAGEPARTIAL = "SuccessMessagePartial";
    const string ERRORMESSAGE = "ErrorMessage";
    const string ERRORMESSAGEPARTIAL = "ErrorMessagePartial";
    const string SINHORARIO = "Sin horarios disponibles";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ReservaResponseDto>>(Constantes.GET, Constantes.GETALLRESERVAS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }
        return View(collection.OrderByDescending(m => m.Id));
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
        var (falloEjecucion, sucursales, servicios, clientes) = await ObtenerValoresInicialesCreateEdit();
        if (falloEjecucion) return RedirectToAction(INDEX);

        var reserva = new ReservaRequestDto()
        {
            Sucursales = sucursales,
            Servicios = servicios,
            Fecha = DateOnly.FromDateTime(DateTime.Now),
            Horarios = new List<ReservaHorario>() { new ReservaHorario() { Hora = SINHORARIO } },
            Clientes = clientes,
            Estado = "P",
            ReservaPregunta = new List<ReservaPreguntaRequestDto>()
            {
                new ReservaPreguntaRequestDto(){ Id = 1, Pregunta = "¿Cuál es el propósito de su visita?" },
                new ReservaPreguntaRequestDto(){ Id = 2, Pregunta = "¿Tiene alguna alergia conocida?" },
                new ReservaPreguntaRequestDto(){ Id = 3, Pregunta = "¿Prefiere alguna hora específica?" },
            },
        };

        return View(reserva);
    }

    [HttpPost]
    public async Task<ActionResult> AgregarEliminarServicio(ReservaRequestDto reserva)
    {
        const string PARTIALVIEWSERVICIOS = "~/Views/Reserva/_ServiciosReserva.cshtml";
        var servicios = await cliente.ConsumirAPIAsync<List<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            TempData[ERRORMESSAGEPARTIAL] = cliente.Error ? cliente.MensajeError : null;
            return PartialView(PARTIALVIEWSERVICIOS, reserva);
        }

        if (reserva.Accion == 'A')
        {
            var servicioSeleccionado = servicios.Single(m => m.Id == reserva.IdServicio);
            var reservaServicio = new ReservaServicioRequestDto()
            {
                IdServicio = servicioSeleccionado.Id,
                Servicio = servicioSeleccionado
            };

            reserva.AgregarServicio(reservaServicio);
        }
        if (reserva.Accion == 'E') reserva.EliminarServicio(reserva.IdServicio);

        var serviciosExistentesReserva = servicios.Where(m => reserva.ReservaServicios.Exists(x => x.IdServicio == m.Id)).ToList();

        servicios.Insert(0, new ServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });
        reserva.Servicios = servicios.Except(serviciosExistentesReserva).ToList();

        string mensajeProceso = reserva.Accion == 'E' ? "eliminado" : "agregado";
        TempData[SUCCESSMESSAGEPARTIAL] = $"Servicio {mensajeProceso} correctamnete";

        return PartialView(PARTIALVIEWSERVICIOS, reserva);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ReservaRequestDto reserva)
    {
        var sucursal = await cliente.ConsumirAPIAsync<IEnumerable<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        if (sucursal == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(INDEX);
        }

        reserva.Sucursales = sucursal;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(reserva);
        }

        var resultado = await cliente.ConsumirAPIAsync<ReservaResponseDto>(Constantes.POST, Constantes.POSTRESERVA, valoresConsumo: Serialization.Serialize(reserva));

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

        var reservas = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (reservas == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        reservas.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una reserva" });

        var reserva = mapper.Map<ReservaRequestDto>(reservaExisting);
        reserva.Sucursales = reservas;

        return View(reserva);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ReservaRequestDto reserva)
    {
        var url = string.Format(Constantes.PUTRESERVA, reserva.Id);
        var reservas = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLRESERVAS);
        if (reservas == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        reservas.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una reserva" });
        reserva.Sucursales = reservas;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(reserva);
        }

        var resultado = await cliente.ConsumirAPIAsync<ReservaResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(reserva));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(reserva);
        }

        TempData["SuccessMessage"] = "Reserva actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    [RolAccess(Rol.ADMINISTRADOR, Rol.MODERADOR)]
    public async Task<IActionResult> AgendaReserva()
    {
        var currentUser = currentUserAccessor.GetCurrentUser();
        var (falloEjecucion, sucursales, servicios, clientes) = await ObtenerValoresInicialesCreateEdit(currentUser.Role == "Moderador");
        if (falloEjecucion) return RedirectToAction(INDEX);

        var reserva = new ReservaRequestDto()
        {
            Sucursales = sucursales,
            UrlAPI = cliente.BaseUrlAPI,
        };

        return View(reserva);
    }

    #region Carga de parciales

    [HttpPost]
    public async Task<IActionResult> CargarHorarios(ReservaRequestDto reserva)
    {
        const string HORARIOPARTIALVIEW = "~/Views/Reserva/_HorariosDisponibles.cshtml";
        string url = String.Format(Constantes.GETALLHORADISPONIBLE, reserva.IdSucursal, reserva.Fecha.ToString("yyyy-MM-dd"));

        var horas = await cliente.ConsumirAPIAsync<List<TimeOnly>>(Constantes.GET, url);
        reserva.Horarios = horas == null ? new List<ReservaHorario>() { new ReservaHorario() { Hora = SINHORARIO } } : (from a in horas select new ReservaHorario() { Horario = a }).ToList();

        return PartialView(HORARIOPARTIALVIEW, reserva);
    }

    #endregion

    private void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private async Task<(bool, List<SucursalResponseDto>, List<ServicioResponseDto>, List<ClienteResponseDto>)> ObtenerValoresInicialesCreateEdit(bool sucursalesByRole = false)
    {
        string url = sucursalesByRole ? Constantes.GETALLSUCURSALESBYROL : Constantes.GETALLSUCURSALES;
        var sucursales = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, url);
        if (sucursales == null)
        {
            SetErrorMessage();
            return (true, null, null, null)!;
        }
        sucursales.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });

        var servicios = await cliente.ConsumirAPIAsync<List<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            SetErrorMessage();
            return (true, null, null, null)!;
        }
        servicios.Insert(0, new ServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });

        var clientes = await cliente.ConsumirAPIAsync<List<ClienteResponseDto>>(Constantes.GET, Constantes.GETALLCLIENTES);
        if (servicios == null)
        {
            SetErrorMessage();
            return (true, null, null, null)!;
        }
        clientes.Insert(0, new ClienteResponseDto() { Id = 0, Nombre = "Seleccione un cliente" });

        return (false, sucursales, servicios, clientes);
    }
}