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
            var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDTO>>(Constantes.GET, Constantes.GETALLPROVINCIA);
            provincias.Insert(0, new ProvinciaResponseDTO() { Id = 0, Nombre = "Seleccione una provincia" });
            var sucursal = new SucursalRequestDTO()
            {
               Provincias = provincias
            };
            return View(sucursal);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SucursalRequestDTO sucursal)
        {
            var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDTO>>(Constantes.GET, Constantes.GETALLPROVINCIA);
            provincias.Insert(0, new ProvinciaResponseDTO() { Id = 0, Nombre = "Seleccione una provincia" });
            sucursal.Provincias = provincias;

            try
            {
                var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.POST, Constantes.POSTSUCURSAL, valoresConsumo: Serialization.Serialize(sucursal));

                TempData["SuccessMessage"] = "Sucursal creada correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(sucursal);
            }
        }

    }
}

