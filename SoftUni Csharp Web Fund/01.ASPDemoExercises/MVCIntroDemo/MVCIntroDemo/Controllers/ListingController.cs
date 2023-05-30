namespace MVCIntroDemo.Controllers;

using Microsoft.AspNetCore.Mvc;

using static Seeding.ListingsSeeder;

public class ListingController : Controller
{
    public IActionResult All()
    {
        return View(Listings);
    }
}