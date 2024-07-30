using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
        var (falloEjecucion, clientes, tipoPagos, usuarioSucursales, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var factura = new FacturaRequestDto()
        {
            Clientes = clientes,
            TipoPagos = tipoPagos,
            Impuestos = impuestos,
            UsuarioSucursales = usuarioSucursales
        };
        return View(factura);
    }

    [HttpPost]
    public async Task<IActionResult> Create(FacturaRequestDto factura)
    {
        var (falloEjecucion, clientes, tipoPagos, usuarioSucursales, impuestos) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        factura.Clientes = clientes;
        factura.TipoPagos = tipoPagos;
        factura.UsuarioSucursales = usuarioSucursales;
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

    private async Task<(bool fallo, IEnumerable<ClienteResponseDto>, IEnumerable<TipoPagoResponseDto>, IEnumerable<UsuarioSucursalResponseDto>, IEnumerable<ImpuestoResponseDto>)> ObtenerValoresInicialesSelect()
    {
        var clientes = await cliente.ConsumirAPIAsync<IEnumerable<ClienteResponseDto>>(Constantes.GET, Constantes.GETALLCLIENTES);
        if (clientes == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null,null,null)!;
        }

        var tipoPagos = await cliente.ConsumirAPIAsync<IEnumerable<TipoPagoResponseDto>>(Constantes.GET, Constantes.GETALLTIPOPAGOS);
        if (tipoPagos == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null, null, null)!;
        }

        var usuarioSucursales = await cliente.ConsumirAPIAsync<IEnumerable<UsuarioSucursalResponseDto>>(Constantes.GET, Constantes.GETALLUSUARIOSUCURSALES);
        if (usuarioSucursales == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null, null, null)!;
        }

        var impuestos = await cliente.ConsumirAPIAsync<IEnumerable<ImpuestoResponseDto>>(Constantes.GET, Constantes.GETALLIMPUESTOS);
        if (impuestos == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null, null, null)!;
        }

        return (false, clientes, tipoPagos, usuarioSucursales, impuestos);
    }
}