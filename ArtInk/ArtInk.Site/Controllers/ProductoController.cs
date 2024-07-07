using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace ArtInk.Site.Controllers
{
    public class ProductoController(IAPIArtInkClient cliente, IMapper mapper) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<ProductoResponseDTO>>(Constantes.GET, Constantes.GETALLPRODUCTOS);
            if (collection == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction("Index", "Home");
            }
            return View(collection);
        }

        public async Task<IActionResult> Details(short id)
        {
            var url = string.Format(Constantes.GETPRODUCTOBYID, id);
            var collection = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.GET, url);

            return View(collection);
        }

        public async Task<IActionResult> Create()
        {
            var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDTO>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
            if (unidadMedida == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
            if (categoria == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            var producto = new ProductoRequestDTO()
            {
                UnidadMedidas = unidadMedida,
                Categorias = categoria
            };
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductoRequestDTO producto)
        {
            var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDTO>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
            if (unidadMedida == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
            if (categoria == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            producto.UnidadMedidas = unidadMedida;
            producto.Categorias = categoria;

            var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.POST, Constantes.POSTPRODUCTO, valoresConsumo: Serialization.Serialize(producto));
            if (resultado == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return View(producto);
            }

            TempData["SuccessMessage"] = "Producto creado correctamente.";

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(short id)
        {
            var url = string.Format(Constantes.GETPRODUCTOBYID, id);
            var productoExisting = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.GET, url);
            if (productoExisting == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index)); 
            }

            var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDTO>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
            if (unidadMedida == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
            if (categoria == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }

            var producto = mapper.Map<ProductoRequestDTO>(productoExisting);
            producto.UnidadMedidas = unidadMedida;
            producto.Categorias = categoria;

            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoRequestDTO producto)
        {
            var url = string.Format(Constantes.PUTPRODUCTO, producto.Id);

            var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDTO>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
            if (unidadMedida == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }
            producto.UnidadMedidas = unidadMedida;

            var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
            if (categoria == null) 
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return RedirectToAction(nameof(Index));
            }
            producto.Categorias = categoria;

            var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(producto));

            if (resultado == null)
            {
                TempData["ErrorMessage"] = cliente.Error ? cliente.MensajeError : null;
                return View(producto);
            }

            TempData["SuccessMessage"] = "Producto actualizado correctamente.";

            return RedirectToAction(nameof(Index));
        }

    }
}
