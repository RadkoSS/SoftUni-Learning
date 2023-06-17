namespace Homies.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using ViewModels.Event;
using Services.Contracts;

public class EventController : BaseController
{
    private readonly IEventService eventService;
    private readonly UserManager<IdentityUser> userManager;

    public EventController(IEventService eventService, UserManager<IdentityUser> userManager)
    {
        this.eventService = eventService;
        this.userManager = userManager;
    }

    public async Task<IActionResult> All()
    {
        var events = await this.eventService.GetAllEventsAsync();

        return View(events);
    }

    public async Task<IActionResult> Add()
    {
        var model = await this.eventService.GetCreateAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventCreateViewAndInputModel input)
    {
        if (!ModelState.IsValid)
        {
            input.Types = await this.eventService.GetEventTypesAsync();

            ModelState.AddModelError("", "Invalid data!");

            return View(input);
        }

        try
        {
            var userId = GetUserId();

            await this.eventService.AddEventAsync(input, userId);
        }
        catch (InvalidDataException e)
        {
            input.Types = await this.eventService.GetEventTypesAsync();

            ModelState.AddModelError("", e.Message);

            return View(input);
        }

        return RedirectToAction("All", "Event");
    }

    public async Task<IActionResult> Joined()
    {
        var userId = GetUserId();

        var events = await this.eventService.GetJoinedEventsAsync(userId);

        return View(events);
    }

    public async Task<IActionResult> Join(string id)
    {
        try
        {
            var userId = GetUserId();

            await this.eventService.JoinEventAsync(int.Parse(id), userId);

            return RedirectToAction("Joined", "Event");
        }
        catch
        {
            return RedirectToAction("All", "Event");
        }
    }

    public async Task<IActionResult> Leave(string id)
    {
        if (int.TryParse(id, out int idAsInt))
        {
            var userId = GetUserId();

            await this.eventService.LeaveEventAsync(idAsInt, userId);

            return RedirectToAction("All", "Event");
        }

        return RedirectToAction("Joined", "Event");
    }

    public async Task<IActionResult> Edit(string id)
    {
        if (int.TryParse(id, out int idAsInt))
        {
            var model = await this.eventService.GetEditAsync(idAsInt);
            model.EventId = idAsInt;
            return View(model);
        }

        return RedirectToAction("All", "Event");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EventCreateViewAndInputModel input)
    {
        if (!ModelState.IsValid)
        {
            input.Types = await this.eventService.GetEventTypesAsync();

            ModelState.AddModelError("", "Invalid data!");

            return View(input);
        }

        try
        {
            await this.eventService.UpdateEventAsync(input);

            return RedirectToAction("All", "Event");
        }
        catch (InvalidDataException e)
        {
            input.Types = await this.eventService.GetEventTypesAsync();

            ModelState.AddModelError("", e.Message);

            return View(input);
        }
    }

    public async Task<IActionResult> Details(string id)
    {
        try
        {
            var model = await this.eventService.GetEventDetailsAsync(int.Parse(id));

            return View(model);
        }
        catch
        {
            return RedirectToAction("All", "Event");
        }
    }

    private string GetUserId()
        => this.userManager.GetUserId(User);
}