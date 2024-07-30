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
    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<FacturaResponseDto>>(Constantes.GET, Constantes.GETALLFACTURAS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
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

    public async Task<IActionResult> Create()
    {
        var (falloEjecucion, clientes, tipoPagos, servicios, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

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
        var servicios = await cliente.ConsumirAPIAsync<List<ServicioResponseDto>>(Constantes.GET, Constantes.GETALLSERVICIOS);
        if (servicios == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return PartialView("~/Views/Factura/_CreateDetalleFactura.cshtml",facturaRequestDto);
        }

        servicios.Insert(0, new ServicioResponseDto() { Id = 0, Nombre = "Seleccione un servicio" });

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
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
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