namespace MVCIntroDemo.Controllers;

using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using Models;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Message"] = "Hello world!";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}