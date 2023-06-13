namespace Contacts.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using ViewModels.User;
using Data.Models.User;

[Authorize]
public class UserController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;

    public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("All", "Contacts");
        }

        var registerInputModel = new RegisterInputViewModel();

        return View(registerInputModel);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterInputViewModel input)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        var newUser = new ApplicationUser
        {
            Email = input.Email,
            UserName = input.UserName
        };

        var result = await this.userManager.CreateAsync(newUser, input.Password);

        if (result.Succeeded)
        {
            return RedirectToAction("Login", "User");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(input);
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("All", "Contacts");
        }

        return View();
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginInputViewModel input)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        var user = await userManager.FindByNameAsync(input.UserName);

        if (user != null)
        {
            var result = await this.signInManager.PasswordSignInAsync(user, input.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToAction("All", "Contacts");
            }

            ModelState.AddModelError(string.Empty, "Invalid login.");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "User does not exist. Go to register.");
        }

        return View(input);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await this.signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}