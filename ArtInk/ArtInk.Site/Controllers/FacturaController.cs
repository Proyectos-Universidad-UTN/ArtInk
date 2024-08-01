using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ArtInk.Site.Controllers;

public class FacturaController(IApiArtInkClient cliente) : Controller
{
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
        return View(collection);
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
        if (idPedido == null)
        {
            TempData[ERRORMESSAGE] = "Se necesita la proforma.";
            return RedirectToAction(INDEXVIEW, CONTROLLERPROFORMA);
        }

        var url = string.Format(Constantes.GETPEDIDOYID, idPedido);
        var pedido = await cliente.ConsumirAPIAsync<PedidoResponseDto>(Constantes.GET, url);

        if (pedido == null)
        {
            SetErrorMessage();
            return RedirectToAction(INDEXVIEW, CONTROLLERPROFORMA);
        }

        var (falloEjecucion, clientes, tipoPagos, servicios, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        // Se remueven los servicios existentes para evitar duplicados en la carga
        var serviciosExistentes = servicios.Where(m => pedido.DetallePedidos.ToList().Exists(x => x.IdServicio == m.Id)).ToList();
        servicios = FiltrarServiciosExistentes(servicios, serviciosExistentes);


        var factura = new FacturaRequestDto()
        {
            Clientes = clientes,
            TipoPagos = tipoPagos,
            Impuestos = impuestos,
            Fecha = DateOnly.FromDateTime(DateTime.Now),
            Servicios = servicios
        };
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
            };

            facturaRequestDto.AgregarDetalleFactura(detalleFactura);
        }

        if (facturaRequestDto.Accion == 'E') facturaRequestDto.EliminarDetalleImpuesto(facturaRequestDto.IdServicio);

        var serviciosExistentes = servicios.Where(m => facturaRequestDto.DetalleFacturas.Exists(x => x.IdServicio == m.Id)).ToList();

        servicios.Except(serviciosExistentes);

        facturaRequestDto.Servicios = servicios;

        return PartialView("~/Views/Factura/_CreateDetalleFactura.cshtml", facturaRequestDto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FacturaRequestDto factura)
    {
        var (falloEjecucion, clientes, tipoPagos, servicios, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        factura.Clientes = clientes;
        factura.TipoPagos = tipoPagos;
        factura.Impuestos = impuestos;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(factura);
        }

        var resultado = await cliente.ConsumirAPIAsync<FacturaResponseDto>(Constantes.POST, Constantes.POSTFACTURA, valoresConsumo: Serialization.Serialize(factura));
        if (resultado == null)
        {
            SetErrorMessage();
            return View(factura);
        }

        TempData["SuccessMessage"] = "Factura creada correctamente.";

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