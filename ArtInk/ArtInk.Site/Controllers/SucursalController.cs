using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class SucursalController(IAPIArtInkClient cliente) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var collection = await cliente.ConsumirAPIAsync<IEnumerable<SucursalResponseDTO>>(Constantes.GET, Constantes.GETALLSUCURSALES);
            return View(collection);
        }

        public async Task<IActionResult> Details(byte id)
        {
            var url = string.Format(Constantes.GETSUCURSALBYID, id);
            var collection = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.GET, url);

            return View(collection);
        }
        public async Task<IActionResult> Create()
        {
            var distrito = await cliente.ConsumirAPIAsync<IEnumerable<DistritoResponseDTO>>(Constantes.GET, Constantes.GETALLDISTRITOS);
            var producto = new DistritoRequestDTO()
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
    }
}

