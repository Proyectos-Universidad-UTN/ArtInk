using ArtInk.Site.Client;
using ArtInk.Site.Common;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ProductoController(IApiArtInkClient cliente, IMapper mapper, ICurrentUserAccessor currentUserAccessor) : BaseArtInkController
{
    const string ERRORMESSAGE = "ErrorMessage";
    const string ROLSINACCESO = "Rol no posee acceso";

    public async Task<IActionResult> Index()
    {
        var collection = await cliente.ConsumirAPIAsync<IEnumerable<ProductoResponseDto>>(Constantes.GET, Constantes.GETALLPRODUCTOS);
        if (collection == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction("Index", "Home");
        }
        return View(collection);
    }

    public async Task<IActionResult> Details(short id)
    {
        var url = string.Format(Constantes.GETPRODUCTOBYID, id);
        var collection = await cliente.ConsumirAPIAsync<ProductoResponseDto>(Constantes.GET, url);

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        return View(collection);
    }

    public async Task<IActionResult> Create()
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var (falloEjecucion, unidadMedidas, categorias) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var producto = new ProductoRequestDto()
        {
            UnidadMedidas = unidadMedidas,
            Categorias = categorias
        };
        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductoRequestDto producto)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var (falloEjecucion, unidadMedidas, categorias) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        producto.UnidadMedidas = unidadMedidas;
        producto.Categorias = categorias;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(producto);
        }

        var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDto>(Constantes.POST, Constantes.POSTPRODUCTO, valoresConsumo: Serialization.Serialize(producto));
        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(producto);
        }

        TempData["SuccessMessage"] = "Producto creado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(short id)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var url = string.Format(Constantes.GETPRODUCTOBYID, id);
        var productoExisting = await cliente.ConsumirAPIAsync<ProductoResponseDto>(Constantes.GET, url);
        if (productoExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var (falloEjecucion, unidadMedidas, categorias) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        var producto = mapper.Map<ProductoRequestDto>(productoExisting);
        producto.UnidadMedidas = unidadMedidas;
        producto.Categorias = categorias;

        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductoRequestDto producto)
    {
        if (currentUserAccessor.GetCurrentUser().Role != "Administrador")
        {
            TempData[ERRORMESSAGE] = ROLSINACCESO;
            return RedirectToAction("Index", "Home");
        }

        var url = string.Format(Constantes.PUTPRODUCTO, producto.Id);

        var (falloEjecucion, unidadMedidas, categorias) = await ObtenerValoresInicialesSelect();
        if (falloEjecucion) return RedirectToAction(nameof(Index));

        producto.UnidadMedidas = unidadMedidas;
        producto.Categorias = categorias;

        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(producto);
        }

        var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDto>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(producto));

        if (resultado == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return View(producto);
        }

        TempData["SuccessMessage"] = "Producto actualizado correctamente.";

        return RedirectToAction(nameof(Index));
    }

    private async Task<(bool fallo, IEnumerable<UnidadMedidaResponseDto>, IEnumerable<CategoriaResponseDto>)> ObtenerValoresInicialesSelect()
    {
        var unidadMedidas = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDto>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
        if (unidadMedidas == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null)!;
        }

        var categorias = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDto>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
        if (categorias == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return (true, null, null)!;
        }

        return (false, unidadMedidas, categorias);
    }
}