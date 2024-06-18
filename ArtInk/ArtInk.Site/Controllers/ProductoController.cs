using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace ArtInk.Site.Controllers
{
    public class ProductoController(IAPIArtInkClient cliente) : Controller
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

            var resultado = await cliente.ConsumirAPIAsync<ProductoResponseDTO>(Constantes.POST, Constantes.POSTPRODUCTO);
            return View(producto);
        }
    }
}
