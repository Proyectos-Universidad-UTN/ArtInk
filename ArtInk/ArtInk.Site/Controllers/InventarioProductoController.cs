using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Common;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class InventarioProducto(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";
    
    public async Task<IActionResult> Index()
    {
        var (falloEjecucion, sucursales, inventarios) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction("Index", "Home");

        var sucursalInventario = new SucursalInventarioProducto()
        {
            UrlAPI = cliente.BaseUrlAPI,
            Sucursales = sucursales,
            Inventarios = inventarios
        };

        return View(sucursalInventario);
    }

    public async Task<IActionResult> Create(short idInventario)
    {
        var (falloEjecucion, productos) = await ObtenerValoresInicialesSelectFormulario(idInventario);
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        if (!ModelState.IsValid || idInventario == 0)
        {
            TempData[ERRORMESSAGE] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        var inventarioProducto = new InventarioProductoRequestDto()
        {
            IdInventario = idInventario,
            Disponible = 0,
            Productos = productos
        };

        return View(inventarioProducto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(InventarioProductoRequestDto inventarioProductoRequestDto)
    {
        var (falloEjecucion, productos) = await ObtenerValoresInicialesSelectFormulario(inventarioProductoRequestDto.IdInventario);
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        inventarioProductoRequestDto.Productos = productos;
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(inventarioProductoRequestDto);
        }

        var resultado = await cliente.ConsumirAPIAsync<InventarioProductoResponseDto>(Constantes.POST, Constantes.POSTINVENTARIOPRODUCTO, valoresConsumo: Serialization.Serialize(inventarioProductoRequestDto));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(inventarioProductoRequestDto);
        }

        TempData["SuccessMessage"] = "Inventario producto creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long id)
    {
        if (!ModelState.IsValid || id == 0)
        {
            TempData[ERRORMESSAGE] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        var url = string.Format(Constantes.GETINVENTARIOPRODUCTO, id);
        var inventarioProductoExisting = await cliente.ConsumirAPIAsync<InventarioProductoRequestDto>(Constantes.GET, url);
        if (inventarioProductoExisting == null || !ModelState.IsValid)
        {
            SetErrorMessage();
            return RedirectToAction(nameof(Index));
        }

        var (falloEjecucion, productos) = await ObtenerValoresInicialesSelectFormulario();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var inventarioProducto = mapper.Map<InventarioProductoRequestDto>(inventarioProductoExisting);
        inventarioProducto.Productos = productos;

        return View(inventarioProducto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(InventarioProductoRequestDto inventarioProductoRequestDto)
    {
        var url = string.Format(Constantes.PUTINVENTARIOPRODUCTO, inventarioProductoRequestDto.Id);

        var (falloEjecucion, productos) = await ObtenerValoresInicialesSelectFormulario();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        inventarioProductoRequestDto.Productos = productos;
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(inventarioProductoRequestDto);
        }

        var resultado = await cliente.ConsumirAPIAsync<InventarioResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(inventarioProductoRequestDto));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(inventarioProductoRequestDto);
        }

        TempData["SuccessMessage"] = "Inventario producto actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    private void SetErrorMessage() => TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;

    private async Task<(bool fallo, List<SucursalResponseDto>, List<InventarioResponseDto>)> ObtenerValoresInicialesSelect()
    {
        var sucursales = await cliente.ConsumirAPIAsync<List<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES);
        var inventarios = new List<InventarioResponseDto>();
        if (sucursales == null)
        {
            SetErrorMessage();
            return (true, null, null)!;
        }
        sucursales.Insert(0, new SucursalResponseDto() { Id = 0, Nombre = "Seleccione una sucursal" });
        inventarios.Insert(0, new InventarioResponseDto() { Id = 0, Nombre = "Seleccione un inventario" });

        return (false, sucursales, inventarios);
    }

    private async Task<(bool, IEnumerable<ProductoResponseDto>)> ObtenerValoresInicialesSelectFormulario(short idInventario = 0)
    {
        var url = idInventario == 0 ? Constantes.GETALLPRODUCTOS : String.Format(Constantes.GETALLPRODUCTOSEXCLUDINGINVENTARIOPRODUCTO, idInventario);
        var productos = await cliente.ConsumirAPIAsync<List<ProductoResponseDto>>(Constantes.GET, url);
        if (productos == null)
        {
            SetErrorMessage();
            return (true, null)!;
        }
        productos.Insert(0, new ProductoResponseDto() { Id = 0, Nombre = "Seleccione un producto" });

        return (false, productos);
    }
}