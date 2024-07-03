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
            var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
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
            var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
            producto.UnidadMedidas = unidadMedida;
            producto.Categorias = categoria;

            try
            {
                var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.POST, Constantes.POSTPRODUCTO, valoresConsumo: Serialization.Serialize(producto));
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(producto);
            }
        }
        public async Task<IActionResult> Edit(short id)
        {
            try
            {
                var url = string.Format(Constantes.GETPRODUCTOBYID, id);
                var productoExisting = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.GET, url);
                if (productoExisting == null) return RedirectToAction(nameof(Index));

                var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDTO>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
                var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
                var producto = mapper.Map<ProductoRequestDTO>(productoExisting);

                producto.UnidadMedidas = unidadMedida;
                producto.Categorias = categoria;

                return View(producto);

            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoRequestDTO producto)
        {
            try
            {
                var url = string.Format(Constantes.PUTPRODUCTO, producto.Id);

                var unidadMedida = await cliente.ConsumirAPIAsync<IEnumerable<UnidadMedidaResponseDTO>>(Constantes.GET, Constantes.GETALLUNIDAMEDIDAS);
                if (unidadMedida == null) return RedirectToAction(nameof(Index));
                producto.UnidadMedidas = unidadMedida;

                var categoria = await cliente.ConsumirAPIAsync<IEnumerable<CategoriaResponseDTO>>(Constantes.GET, Constantes.GETALLCATEGORIAS);
                if (categoria == null) return RedirectToAction(nameof(Index));
                producto.Categorias = categoria;

                var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.POST, Constantes.POSTPRODUCTO, valoresConsumo: Serialization.Serialize(producto));
                if (resultado == null) return View(producto);

                TempData["SuccessMessage"] = "Producto actualizado correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
