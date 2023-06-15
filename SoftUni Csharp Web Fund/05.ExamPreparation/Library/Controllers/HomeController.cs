namespace Library.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

public class HomeController : BaseController
{
    [AllowAnonymous]
    public IActionResult Index()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("All", "Books");
        }

        return View();
    }
}