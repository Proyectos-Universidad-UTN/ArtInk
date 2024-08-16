using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class FacturaController(IApiArtInkClient cliente) : BaseArtInkController
{
    const string SUCCESSMESSAGEPARTIAL = "SuccessMessagePartial";
    const string ERRORMESSAGE = "ErrorMessage";
    const string INDEXVIEW = "Index";
    const string CONTROLLERPROFORMA = "Proforma";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<FacturaResponseDto>>(Constantes.GET, Constantes.GETALLFACTURAS);
        if (collection == null)
        {
            SetErrorMessage();
            return RedirectToAction(INDEXVIEW, "Home");
        }
        return View(collection.OrderByDescending(m => m.Id));
    }

    public async Task<IActionResult> Details(long id)
    {
        var url = string.Format(Constantes.GETFACTURABYID, id);
        var collection = await cliente.ConsumirAPIAsync<FacturaResponseDto>(Constantes.GET, url);

        if (!ModelState.IsValid)
        {
            TempData["ErrorMessage"] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        return View(collection);
    }

    public async Task<IActionResult> Create(long? idPedido)
    {
        PedidoResponseDto pedido = null!;

        if (idPedido != null)
        {
            var url = string.Format(Constantes.GETPEDIDOYID, idPedido);
            pedido = await cliente.ConsumirAPIAsync<PedidoResponseDto>(Constantes.GET, url);

            if (pedido == null)
            {
                SetErrorMessage();
                return RedirectToAction(INDEXVIEW, CONTROLLERPROFORMA);
            }
            
            if (pedido.Estado == 'F')
            {
                TempData[ERRORMESSAGE] = "No se puede generar otra factura de una proforma ya procesada";
                return RedirectToAction(INDEXVIEW, CONTROLLERPROFORMA);
            }
        }

        var (falloEjecucion, sucursales, clientes, tipoPagos, servicios, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var factura = ObtenerModelCreate(servicios, pedido);
        factura.Sucursales = sucursales;
        factura.Clientes = clientes;
        factura.TipoPagos = tipoPagos;
        factura.Impuestos = impuestos;

        return View(factura);
    }

    public async Task<IActionResult> AgregarEliminarLineaFactura(FacturaRequestDto facturaRequestDto)
    {
        var (falloEjecucion, servicios) = await ObtenerValoresServicioselect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        if (facturaRequestDto.Accion == 'A')
        {
            var servicioSeleccionado = servicios.Single(m => m.Id == facturaRequestDto.IdServicio);
            var numeroLinea = facturaRequestDto.SiguienteNumeroLinea();
            var detalleFactura = new DetalleFacturaRequestDto()
            {
                NumeroLinea = numeroLinea,
                Servicio = servicioSeleccionado,
                TarifaServicio = servicioSeleccionado.Tarifa,
                IdServicio = facturaRequestDto.IdServicio,
                Cantidad = 0,
                MontoSubtotal = 0,
                MontoImpuesto = 0,
                MontoTotal = 0,
            };

            facturaRequestDto.AgregarDetalleFactura(detalleFactura);
        }

        if (facturaRequestDto.Accion == 'E') facturaRequestDto.EliminarDetalleImpuesto(facturaRequestDto.NumeroLineaEliminar);

        var serviciosExistentes = servicios.Where(m => facturaRequestDto.DetalleFacturas.Exists(x => x.IdServicio == m.Id)).ToList();

        facturaRequestDto.Servicios = FiltrarServiciosExistentes(servicios, serviciosExistentes);

        string mensajeProceso = facturaRequestDto.Accion == 'E' ? "eliminado" : "agregado";
        TempData[SUCCESSMESSAGEPARTIAL] = $"Detalle {mensajeProceso} correctamnete";

        return PartialView("~/Views/Factura/_CreateDetalleFactura.cshtml", facturaRequestDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FacturaRequestDto facturaRequestDto)
    {
        var (falloEjecucion, sucursales, clientes, tipoPagos, servicios, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        facturaRequestDto.Sucursales = sucursales;
        facturaRequestDto.Clientes = clientes;
        facturaRequestDto.TipoPagos = tipoPagos;
        facturaRequestDto.Impuestos = impuestos;
        facturaRequestDto.Servicios = servicios;

        facturaRequestDto.CalcularTotales();

        if (facturaRequestDto.MontoTotal <= 0 || facturaRequestDto.DetalleFacturas.Count == 0 || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = !ModelState.IsValid ? string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage)) : facturaRequestDto.MontoTotal <= 0 ? "Una factura no puede guardarse con un total de 0" : "Debe agregar detalles a la Factura";

            return View(facturaRequestDto);
        }

        var resultado = await cliente.ConsumirAPIAsync<FacturaResponseDto>(Constantes.POST, Constantes.POSTFACTURA, valoresConsumo: Serialization.Serialize(facturaRequestDto));
        if (resultado == null)
        {
            SetErrorMessage();
            return View(facturaRequestDto);
        }

        TempData["SuccessMessage"] = "Factura creada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    private async Task<(bool fallo, IEnumerable<SucursalResponseDto>, IEnumerable<ClienteResponseDto>, IEnumerable<TipoPagoResponseDto>, IEnumerable<ServicioResponseDto>, IEnumerable<ImpuestoResponseDto>)> ObtenerValoresInicialesSelect()
    {
        string url = Constantes.GETALLSUCURSALES;
        var sucursales = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, url);
        if (sucursales == null)
        {
            SetErrorMessage();
            return (true, null, null, null, null, null)!;
        }
        sucursales.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });

        var clientes = await cliente.ConsumirAPIAsync<List<ClienteResponseDto>>(Constantes.GET, Constantes.GETALLCLIENTES);
        if (clientes == null)
        {
            SetErrorMessage();
            return (true, null, null, null, null, null)!;
        }

        clientes.Insert(0, new ClienteResponseDto() { Id = 0, Nombre = "Seleccione un cliente" });

        var tipoPagos = await cliente.ConsumirAPIAsync<List<TipoPagoResponseDto>>(Constantes.GET, Constantes.GETALLTIPOPAGOS);
        if (tipoPagos == null)
        {
            SetErrorMessage();
            return (true, null, null, null, null, null)!;
        }

        tipoPagos.Insert(0, new TipoPagoResponseDto() { Id = 0, Descripcion = "Seleccione un tipo de pago" });

        var impuestos = await cliente.ConsumirAPIAsync<List<ImpuestoResponseDto>>(Constantes.GET, Constantes.GETALLIMPUESTOS);
        if (impuestos == null)
        {
            SetErrorMessage();
            return (true, null, null, null, null, null)!;
        }

        impuestos.Insert(0, new ImpuestoResponseDto() { Id = 0, Nombre = "Seleccione un impuesto" });

        var (falloEjecucion, servicios) = await ObtenerValoresServicioselect();
        if (servicios == null)
        {
            SetErrorMessage();
            return (true, null, null, null, null, null)!;
        }

        return (false, sucursales, clientes, tipoPagos, servicios, impuestos);
    }

    private async Task<(bool fallo, IEnumerable<ServicioResponseDto>)> ObtenerValoresServicioselect()
    {
        var servicios = await cliente.ConsumirAPIAsync<List<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }

        servicios.Insert(0, new ServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });

        return (false, servicios);
    }

    private void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private FacturaRequestDto ObtenerModelCreate(IEnumerable<ServicioResponseDto> servicios, PedidoResponseDto? pedido = null!)
    {
        if (pedido == null)
        {
            return new FacturaRequestDto()
            {
                Fecha = DateOnly.FromDateTime(DateTime.Now),
                Servicios = servicios
            };
        }

        // Se remueven los servicios existentes para evitar duplicados en la carga
        var serviciosExistentes = servicios.Where(m => pedido.DetallePedidos.ToList().Exists(x => x.IdServicio == m.Id)).ToList();
        servicios = FiltrarServiciosExistentes(servicios, serviciosExistentes);

        var factura = new FacturaRequestDto()
        {
            IdSucursal = pedido.IdSucursal,
            IdCliente = pedido.IdCliente,
            NombreCliente = pedido.NombreCliente,
            IdPedido = pedido.Id,
            PorcentajeImpuesto = pedido.PorcentajeImpuesto,
            Fecha = DateOnly.FromDateTime(DateTime.Now),
            IdTipoPago = pedido.IdTipoPago,
            IdImpuesto = pedido.IdImpuesto,
            Servicios = servicios
        };
        factura.PrecargarDetalle(pedido.DetallePedidos);
        return factura;
    }

    private List<ServicioResponseDto> FiltrarServiciosExistentes(IEnumerable<ServicioResponseDto> servicios, List<ServicioResponseDto> serviciosExistentes) => servicios.Except(serviciosExistentes).ToList();
}