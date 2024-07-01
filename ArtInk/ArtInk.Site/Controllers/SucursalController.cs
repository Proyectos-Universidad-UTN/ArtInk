using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class SucursalController(IAPIArtInkClient cliente, IMapper mapper) : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                var collection = await cliente.ConsumirAPIAsync<IEnumerable<SucursalResponseDTO>>(Constantes.GET, Constantes.GETALLSUCURSALES);
                return View(collection);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Details(byte id)
        {
            try
            {
                var url = string.Format(Constantes.GETSUCURSALBYID, id);
                var sucursal = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.GET, url);

                return View(sucursal);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDTO>>(Constantes.GET, Constantes.GETALLPROVINCIA);
                provincias.Insert(0, new ProvinciaResponseDTO() { Id = 0, Nombre = "Seleccione una provincia" });
                var sucursal = new SucursalRequestDTO()
                {
                    Provincias = provincias
                };
                return View(sucursal);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(SucursalRequestDTO sucursal)
        {
            try
            {
                var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDTO>>(Constantes.GET, Constantes.GETALLPROVINCIA);
                provincias.Insert(0, new ProvinciaResponseDTO() { Id = 0, Nombre = "Seleccione una provincia" });
                sucursal.Provincias = provincias;

                if (!ModelState.IsValid) return View(sucursal);

                var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.POST, Constantes.POSTSUCURSAL, valoresConsumo: Serialization.Serialize(sucursal));

                TempData["SuccessMessage"] = "Sucursal creada correctamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(sucursal);
            }
        }

        public async Task<IActionResult> Edit(byte id)
        {
            try
            {
                var url = string.Format(Constantes.GETSUCURSALBYID, id);
                var sucursalExisting = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.GET, url);

                var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDTO>>(Constantes.GET, Constantes.GETALLPROVINCIA);
                provincias.Insert(0, new ProvinciaResponseDTO() { Id = 0, Nombre = "Seleccione una provincia" });

                var sucursal = mapper.Map<SucursalRequestDTO>(sucursalExisting);
                sucursal.Provincias = provincias;
                sucursal.IdDistrito = sucursalExisting.IdDistrito;
                sucursal.IdCanton = sucursalExisting.Distrito.IdCanton;
                sucursal.IdProvincia = sucursalExisting.Distrito.Canton.IdProvincia;
                
                return View(sucursal);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SucursalRequestDTO sucursal)
        {
            try
            {
                var url = string.Format(Constantes.PUTSUCURSAL, sucursal.Id);
                var provincias = await cliente.ConsumirAPIAsync<List<ProvinciaResponseDTO>>(Constantes.GET, Constantes.GETALLPROVINCIA);
                provincias.Insert(0, new ProvinciaResponseDTO() { Id = 0, Nombre = "Seleccione una provincia" });
                sucursal.Provincias = provincias;
                sucursal.Activo = true;

                if (!ModelState.IsValid) return View(sucursal);

                var resultado = await cliente.ConsumirAPIAsync<SucursalResponseDTO>(Constantes.PUT, url, valoresConsumo: Serialization.Serialize(sucursal));

                TempData["SuccessMessage"] = "Sucursal actualizada correctamente.";
                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }

    }
}

