using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ProveedorController(IApiArtInkClient cliente, IMapper mapper) : BaseArtInkController
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string SUCCESSMESSAGE = "SuccessMessage";
    const string SELECCIONEPROVINCIA = "Seleccione una provincia";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ProveedorResponseDto>>(Constantes.GET, Constantes.GETALLPROVEEDOR);
        if (collection == null)
        {
            SetErrorMessage();
            return RedirectToAction("Index", "Home");
        }
        return View(collection);
    }

    public async Task<IActionResult> Create()
    {
        var (falloEjecucion, provincias) = await GetValoresInicialesSelect();
        if (falloEjecucion) RedirectToAction(nameof(Index));

        var proveedor = new ProveedorRequestDto()
        {
            Provincias = provincias
        };
        return View(proveedor);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProveedorRequestDto proveedor)
    {
        var (falloEjecucion, provincias) = await GetValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        proveedor.Provincias = provincias;
        proveedor.IdCanton = proveedor.IdCanton;
        proveedor.IdDistrito = proveedor.IdDistrito;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(proveedor);
        }

        var resultado = await cliente.ConsumirAPIAsync<ProveedorResponseDto>(Constantes.POST, Constantes.POSTPROVEEDOR, valoresConsumo: Serialization.Serialize(proveedor));
        if (resultado == null)
        {
            SetErrorMessage();
            return View(proveedor);
        }

        TempData[SUCCESSMESSAGE] = "Proveedor creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(byte id)
    {
        var url = string.Format(Constantes.GETPROVEEDORBYID, id);
        var proveedorExisting = await cliente.ConsumirAPIAsync<ProveedorResponseDto>(Constantes.GET, url);
        if (proveedorExisting == null || !ModelState.IsValid)
        {
            SetErrorMessage();
            return RedirectToAction(nameof(Index));
        }

        var (falloEjecucion, provincias) = await GetValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var proveedor = mapper.Map<ProveedorRequestDto>(proveedorExisting);
        proveedor.Provincias = provincias;
        proveedor.IdDistrito = proveedorExisting.IdDistrito;
        proveedor.IdCanton = proveedorExisting.Distrito.IdCanton;
        proveedor.IdProvincia = proveedorExisting.Distrito.Canton.IdProvincia;

        return View(proveedor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProveedorRequestDto proveedor)
    {
        var url = string.Format(Constantes.PUTPROVEEDOR, proveedor.Id);
         var (falloEjecucion, provincias) = await GetValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        proveedor.Provincias = provincias;
        proveedor.IdCanton = proveedor.IdCanton;
        proveedor.IdDistrito = proveedor.IdDistrito;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(proveedor);
        }

        var resultado = await cliente.ConsumirAPIAsync<ProveedorResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(proveedor));
        if (resultado == null)
        {
            SetErrorMessage();
            return View(proveedor);
        }

        TempData[SUCCESSMESSAGE] = "Proveedor actualizada correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> Delete(byte id)
    {
        var url = string.Format(Constantes.DELETEPROVEEDOR, id);

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return RedirectToAction(nameof(Index));
        }


        var resultado = await cliente.ConsumirAPIAsync<bool>(Constantes.DELETE, url);

        if (!resultado)
        {
            SetErrorMessage();
            return RedirectToAction(nameof(Index));
        }

        TempData[SUCCESSMESSAGE] = "Proveedor eliminado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private async Task<(bool, List<ProvinciaResponseDto>)> GetValoresInicialesSelect()
    {
        var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDto>>(Constantes.GET, Constantes.GETALLPROVINCIA);
        if (provincias == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }

        provincias.Insert(0, new ProvinciaResponseDto() { Id = 0, Nombre = SELECCIONEPROVINCIA });

        return (false, provincias)!;
    }
}