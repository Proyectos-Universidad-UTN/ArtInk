using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ProformaController(IApiArtInkClient cliente) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string INDEXVIEW = "Index";
    const string CONTROLLERRESERVA = "Reserva";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<PedidoResponseDto>>(Constantes.GET, Constantes.GETALLPEDIDOS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEXVIEW, "Home");

        }
        return View(collection);
    }

    public async Task<IActionResult> Create(int? idReserva)
    {
        if (idReserva == null)
        {
            TempData[ERRORMESSAGE] = "Se necesita primero la reserva.";
            return RedirectToAction(INDEXVIEW, CONTROLLERRESERVA);
        }

        var url = string.Format(Constantes.GETRESERVABYID, idReserva);
        var reserva = await cliente.ConsumirAPIAsync<ReservaResponseDto>(Constantes.GET, url);

        if (reserva == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(INDEXVIEW, CONTROLLERRESERVA);
        }

        if (reserva.Estado == "A")
        {
            TempData[ERRORMESSAGE] = "No se puede generar otra proforma de una reserva ya procesada";
            return RedirectToAction(INDEXVIEW, CONTROLLERRESERVA);
        }

        var (falloEjecucion, clientes, tipoPagos, servicios, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        // Se remueven los servicios existentes para evitar duplicados en la carga
        var serviciosExistentes = servicios.Where(m => reserva.ReservaServicios.ToList().Exists(x => x.IdServicio == m.Id)).ToList();
        servicios = servicios.Except(serviciosExistentes).ToList();

        var pedido = new PedidoRequestDto()
        {
            IdCliente = reserva.IdCliente,
            NombreCliente = reserva.NombreCliente,
            IdReserva = idReserva.Value,
            Clientes = clientes,
            TipoPagos = tipoPagos,
            Impuestos = impuestos,
            PorcentajeImpuesto = 0,
            Fecha = DateOnly.FromDateTime(DateTime.Now),
            Servicios = servicios
        };

        pedido.PrecargarDetalle(reserva.ReservaServicios);
        return View(pedido);
    }

    public async Task<IActionResult> AgregarEliminarLineaPedido(PedidoRequestDto pedidoRequestDto)
    {
        var servicios = await cliente.ConsumirAPIAsync<List<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return PartialView("~/Views/Proforma/_CreateDetallePedido.cshtml", pedidoRequestDto);
        }

        servicios.Insert(0, new ServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });

        if (pedidoRequestDto.Accion == 'A')
        {
            var servicioSeleccionado = servicios.Single(m => m.Id == pedidoRequestDto.IdServicio);
            var numeroLinea = pedidoRequestDto.SiguienteNumeroLinea();
            var detallePedido = new DetallePedidoRequestDto()
            {
                NumeroLinea = numeroLinea,
                Servicio = servicioSeleccionado,
                TarifaServicio = servicioSeleccionado.Tarifa,
                IdServicio = pedidoRequestDto.IdServicio,
                Cantidad = 0,
                MontoSubtotal = 0,
                MontoImpuesto = 0,
                MontoTotal = 0,
            };

            pedidoRequestDto.AgregarDetallePedido(detallePedido);
        }

        if (pedidoRequestDto.Accion == 'E') pedidoRequestDto.EliminarDetalleImpuesto(pedidoRequestDto.NumeroLineaEliminar);

        var serviciosExistentes = servicios.Where(m => pedidoRequestDto.DetallePedidos.Exists(x => x.IdServicio == m.Id)).ToList();

        servicios = servicios.Except(serviciosExistentes).ToList();

        pedidoRequestDto.Servicios = servicios;

        return PartialView("~/Views/Proforma/_CreateDetallePedido.cshtml", pedidoRequestDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PedidoRequestDto pedidoRequestDto)
    {
        var (falloEjecucion, clientes, tipoPagos, servicios, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        pedidoRequestDto.Clientes = clientes;
        pedidoRequestDto.TipoPagos = tipoPagos;
        pedidoRequestDto.Impuestos = impuestos;
        pedidoRequestDto.Servicios = servicios;

        pedidoRequestDto.CalcularTotales();

        if (pedidoRequestDto.MontoTotal <= 0)
        {
            TempData[ERRORMESSAGE] = "Una proforma no puede guardarse con un total de 0";
            return View(pedidoRequestDto);
        }

        if (pedidoRequestDto.DetallePedidos.Count == 0)
        {
            TempData[ERRORMESSAGE] = "Debe agregar detalles a la proforma";
            return View(pedidoRequestDto);
        }

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(pedidoRequestDto);
        }

        var resultado = await cliente.ConsumirAPIAsync<PedidoResponseDto>(Constantes.POST, Constantes.POSTPEDIDO, valoresConsumo: Serialization.Serialize(pedidoRequestDto));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(pedidoRequestDto);
        }

        TempData["SuccessMessage"] = "Pedido creada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    private async Task<(bool fallo, IEnumerable<ClienteResponseDto>, IEnumerable<TipoPagoResponseDto>, IEnumerable<ServicioResponseDto>, IEnumerable<ImpuestoResponseDto>)> ObtenerValoresInicialesSelect()
    {
        var clientes = await cliente.ConsumirAPIAsync<List<ClienteResponseDto>>(Constantes.GET, Constantes.GETALLCLIENTES);
        if (clientes == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null, null, null)!;
        }

        clientes.Insert(0, new ClienteResponseDto() { Id = 0, Nombre = "Seleccione un cliente" });

        var tipoPagos = await cliente.ConsumirAPIAsync<List<TipoPagoResponseDto>>(Constantes.GET, Constantes.GETALLTIPOPAGOS);
        if (tipoPagos == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null, null, null)!;
        }

        tipoPagos.Insert(0, new TipoPagoResponseDto() { Id = 0, Descripcion = "Seleccione un tipo de pago" });

        var impuestos = await cliente.ConsumirAPIAsync<List<ImpuestoResponseDto>>(Constantes.GET, Constantes.GETALLIMPUESTOS);
        if (impuestos == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null, null, null)!;
        }

        impuestos.Insert(0, new ImpuestoResponseDto() { Id = 0, Nombre = "Seleccione un impuesto" });

        var servicios = await cliente.ConsumirAPIAsync<List<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null, null, null)!;
        }

        servicios.Insert(0, new ServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });

        return (false, clientes, tipoPagos, servicios, impuestos);
    }
}