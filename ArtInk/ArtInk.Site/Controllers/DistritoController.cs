using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers
{
    public class DistritoController(IAPIArtInkClient distritoCliente) : Controller
    {
        public async Task<IEnumerable<DistritoResponseDTO>> ObtenerDistritos(byte idCanton)
        {
            var url = string.Format(Constantes.GETALLDISTRITOSBYCANTON, idCanton);
            var collection = await distritoCliente.ConsumirAPIAsync<IEnumerable<DistritoResponseDTO>>(Constantes.GET, url);
            return collection;
        }

        public async Task<DistritoResponseDTO> ObtenerDistrito(byte id)
        {
            var url = string.Format(Constantes.GETALLDISTRITOS, id);
            var distrito = await distritoCliente.ConsumirAPIAsync<DistritoResponseDTO>(Constantes.GET, url);
            return distrito;
        }
    }
}
