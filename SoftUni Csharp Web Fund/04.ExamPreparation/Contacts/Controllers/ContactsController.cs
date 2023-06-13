namespace Contacts.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using Data.Models.User;
using Services.Contracts;
using ViewModels.Contact;

[Authorize]
public class ContactsController : Controller
{
    private readonly IContactsService contactsService;
    private readonly UserManager<ApplicationUser> userManager;

    public ContactsController(IContactsService contactsService, UserManager<ApplicationUser> userManager)
    {
        this.contactsService = contactsService;
        this.userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var allContactsViewModel = await contactsService.GetAllContactsAsync();

        allContactsViewModel.UserId = userManager.GetUserId(User);

        return View(allContactsViewModel);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(ContactInputModel input)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        try
        {
            await this.contactsService.CreateContactAsync(input);
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Unsuccessful create.");
            return View(input);
        }

        return RedirectToAction("All", "Contacts");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string contactId)
    {
        try
        {
            var contactViewModel = await this.contactsService.GetContactByIdAsync(contactId);

            return View(contactViewModel);
        }
        catch
        {
            return RedirectToAction("All", "Contacts");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ContactInputModel input)
    {
        if (!ModelState.IsValid)
        {
            return View(input);
        }

        try
        {
            await this.contactsService.EditContactAsync(input);

            return RedirectToAction("All", "Contacts");
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "Unsuccessful edit.");
            return View(input);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddToTeam(string contactId)
    {
        try
        {
            var userId = userManager.GetUserId(User);

            await this.contactsService.AddContactToUserTeamAsync(contactId, userId);

            return RedirectToAction("All", "Contacts");
        }
        catch
        {
            //ToDo: Implement toastr error notifications
            return RedirectToAction("All", "Contacts");
        }
    }

    [HttpGet]
    public async Task<IActionResult> Team()
    {
        try
        {
            var userId = userManager.GetUserId(User);

            var userTeam = await this.contactsService.GetUserContactsByIdAsync(userId);

            return View(userTeam);
        }
        catch
        {
            return RedirectToAction("All", "Contacts");
        }
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromTeam(string contactId)
    {
        try
        {
            var userId = userManager.GetUserId(User);

            await this.contactsService.RemoveContactFromUserTeamAsync(userId, contactId);

            return RedirectToAction("Team", "Contacts");
        }
        catch
        {
            return RedirectToAction("Team", "Contacts");
        }
    }
}