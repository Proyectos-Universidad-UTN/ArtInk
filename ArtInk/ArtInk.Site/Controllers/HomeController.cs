using ArtInk.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArtInk.Site.Controllers;

public class HomeController : BaseArtInkController
{
    public IActionResult Index()
    {
        return View();
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