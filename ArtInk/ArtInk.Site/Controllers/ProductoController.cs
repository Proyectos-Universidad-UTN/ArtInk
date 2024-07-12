using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class ProductoController(IApiArtInkClient cliente, IMapper mapper) : Controller
{
    const string ERRORMESSAGE = "ErrorMessage";

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
            TempData["ErrorMessage"] = "Valores de modelo invalidos";
            return RedirectToAction(nameof(Index));
        }

        return View(collection);
    }

    public async Task<IActionResult> Create()
    {
        var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDto>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
        if (unidadMedida == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDto>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
        if (categoria == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var producto = new ProductoRequestDto()
        {
            UnidadMedidas = unidadMedida,
            Categorias = categoria
        };
        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductoRequestDto producto)
    {
        var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDto>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
        if (unidadMedida == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDto>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
        if (categoria == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        producto.UnidadMedidas = unidadMedida;
        producto.Categorias = categoria;

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
        var url = string.Format(Constantes.GETPRODUCTOBYID, id);
        var productoExisting = await cliente.ConsumirAPIAsync<ProductoResponseDto>(Constantes.GET, url);
        if (productoExisting == null || !ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDto>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
        if (unidadMedida == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDto>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
        if (categoria == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }

        var producto = mapper.Map<ProductoRequestDto>(productoExisting);
        producto.UnidadMedidas = unidadMedida;
        producto.Categorias = categoria;

        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductoRequestDto producto)
    {
        var url = string.Format(Constantes.PUTPRODUCTO, producto.Id);

        var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDto>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
        if (unidadMedida == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }
        producto.UnidadMedidas = unidadMedida;

        var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDto>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
        if (categoria == null)
        {
            TempData[ERRORMESSAGE] = cliente.Error ? cliente.MensajeError : null;
            return RedirectToAction(nameof(Index));
        }
        producto.Categorias = categoria;

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

}