using ArtInk.Site.Client;
using ArtInk.Site.Configuration;
using ArtInk.Site.ViewModels.Request.Authentication;
using ArtInk.Site.ViewModels.Response;
using ArtInk.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ArtInk.Site.Controllers;

public class HomeController(IApiArtInkClient apiArtInkClient) : BaseArtInkController
{
    const string ERRORMESSAGE = "ErrorMessage";

    public IActionResult InicioSesion(string? errorCode)
    {
        if (errorCode != null)
        {
            TempData[ERRORMESSAGE] = "Favor autenticarse en el sistema";
            HttpContext.Response.Cookies.Delete("JWT");
            HttpContext.Response.Cookies.Delete("Refresh-Token");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> InicioSesion(InicioSesionRequest inicioSesion)
    {
        if (!ModelState.IsValid)
        {
            TempData[ERRORMESSAGE] = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
            return View(inicioSesion);
        }

        var respuestaInicioSesion = await apiArtInkClient.ConsumirAPIAsync<AuthenticationResponse>(Constantes.POST, Constantes.GETAUTHTOKEN, incluyeAuthorization: false, valoresConsumo: Serialization.Serialize(inicioSesion));
        if (respuestaInicioSesion == null)
        {
            TempData[ERRORMESSAGE] = apiArtInkClient.MensajeError;
            return View(inicioSesion);
        }

        HttpContext.Response.Cookies.Append("JWT", respuestaInicioSesion.Token);
        HttpContext.Response.Cookies.Append("Refresh-Token", respuestaInicioSesion.RefreshToken);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Index(string? errorCode)
    {
        if (errorCode != null && errorCode == "1") TempData[ERRORMESSAGE] = "No posee acceso a este recurso";

        var cookie = HttpContext.Request.Cookies["JWT"];
        if (!string.IsNullOrEmpty(errorCode) && errorCode == "1" && cookie == null) return RedirectToAction(nameof(InicioSesion), new { errorCode = 2 });
        if(!string.IsNullOrEmpty(errorCode) && errorCode == "2") TempData[ERRORMESSAGE] = "Rol sin permisos";

        var sucursales = await apiArtInkClient.ConsumirAPIAsync<IEnumerable<SucursalResponseDto>>(Constantes.GET, Constantes.GETALLSUCURSALES, incluyeAuthorization: false);
        if (sucursales == null)
        {
            TempData[ERRORMESSAGE] = apiArtInkClient.Error ? apiArtInkClient.MensajeError : "Se ha presentado un error al momento de cargar las sucursales";
            sucursales = new List<SucursalResponseDto>();
        }

        return View(sucursales);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }

    [Route("/NotFound")]
    public IActionResult PageNotFound()
    {
        return View();
    }
}