using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ProformaController(IApiArtInkClient cliente) : BaseArtInkController
{
    const string SUCCESSMESSAGEPARTIAL = "SuccessMessagePartial";
    const string ERRORMESSAGE = "ErrorMessage";
    const string INDEXVIEW = "Index";
    const string CONTROLLERRESERVA = "Reserva";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<PedidoResponseDto>>(Constantes.GET, Constantes.GETALLPEDIDOS);
        if (collection == null)
        {
            SetErrorMessage();
            return RedirectToAction(INDEXVIEW, "Home");

        }
        return View(collection.OrderByDescending(m => m.Id));
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
            SetErrorMessage();
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
        servicios = FiltrarServiciosExistentes(servicios, serviciosExistentes);

        var pedido = new PedidoRequestDto()
        {
            IdReserva = reserva.Id,
            IdCliente = reserva.IdCliente,
            NombreCliente = reserva.NombreCliente,
            IdSucursal = reserva.IdSucursal,
            Clientes = clientes,
            TipoPagos = tipoPagos,
            Impuestos = impuestos,
            PorcentajeImpuesto = 0,
            Fecha = DateOnly.FromDateTime(DateTime.Now),
            Estado = 'P',
            Servicios = servicios
        };

        pedido.PrecargarDetalle(reserva.ReservaServicios);
        return View(pedido);
    }

    public async Task<IActionResult> AgregarEliminarLineaPedido(PedidoRequestDto pedidoRequestDto)
    {
        var (falloEjecucion, servicios) = await ObtenerValoresServicioselect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

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
        pedidoRequestDto.Servicios = FiltrarServiciosExistentes(servicios, serviciosExistentes);

        string mensajeProceso = pedidoRequestDto.Accion == 'E' ? "eliminado" : "agregado";
        TempData[SUCCESSMESSAGEPARTIAL] = $"Detalle {mensajeProceso} correctamnete";

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

        if (pedidoRequestDto.MontoTotal <= 0 || pedidoRequestDto.DetallePedidos.Count == 0 || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = !ModelState.IsValid ? string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage)) : pedidoRequestDto.MontoTotal <= 0 ? "Una proforma no puede guardarse con un total de 0" : "Debe agregar detalles a la proforma";

            return View(pedidoRequestDto);
        }

        var resultado = await cliente.ConsumirAPIAsync<PedidoResponseDto>(Constantes.POST, Constantes.POSTPEDIDO, valoresConsumo: Serialization.Serialize(pedidoRequestDto));
        if (resultado == null)
        {
            SetErrorMessage();
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
            SetErrorMessage();
            return (true, null, null, null, null)!;
        }

        clientes.Insert(0, new ClienteResponseDto() { Id = 0, Nombre = "Seleccione un cliente" });

        var tipoPagos = await cliente.ConsumirAPIAsync<List<TipoPagoResponseDto>>(Constantes.GET, Constantes.GETALLTIPOPAGOS);
        if (tipoPagos == null)
        {
            SetErrorMessage();
            return (true, null, null, null, null)!;
        }

        tipoPagos.Insert(0, new TipoPagoResponseDto() { Id = 0, Descripcion = "Seleccione un tipo de pago" });

        var impuestos = await cliente.ConsumirAPIAsync<List<ImpuestoResponseDto>>(Constantes.GET, Constantes.GETALLIMPUESTOS);
        if (impuestos == null)
        {
            SetErrorMessage();
            return (true, null, null, null, null)!;
        }

        impuestos.Insert(0, new ImpuestoResponseDto() { Id = 0, Nombre = "Seleccione un impuesto" });

        var (falloEjecucion, servicios) = await ObtenerValoresServicioselect();
        if (servicios == null)
        {
            SetErrorMessage();
            return (falloEjecucion, null, null, null, null)!;
        }

        return (false, clientes, tipoPagos, servicios, impuestos);
    }

    private async Task<(bool fallo, IEnumerable<ServicioResponseDto>)> ObtenerValoresServicioselect()
    {
        var servicios = await cliente.ConsumirAPIAsync<List<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            SetErrorMessage();
            return (true,  null)!;
        }

        servicios.Insert(0, new ServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });

        return (false, servicios);
    }

    private void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private List<ServicioResponseDto> FiltrarServiciosExistentes(IEnumerable<ServicioResponseDto> servicios, List<ServicioResponseDto> serviciosExistentes) => servicios.Except(serviciosExistentes).ToList();
}