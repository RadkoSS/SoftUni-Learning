// ReSharper disable InconsistentNaming
namespace ForumApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

using ViewModels.Post;
using Services.Contracts;

[Authorize]
public class PostsController : Controller
{
    private readonly IPostsService postsService;
    private readonly UserManager<IdentityUser> userManager;

    public PostsController(UserManager<IdentityUser> userManager, IPostsService postsService)
    {
        this.postsService = postsService;
        this.userManager = userManager;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> All()
    {
        var user = await GetUserAsync();

        var posts = await this.postsService.GetAllPostsAsync(user?.Id);

        return View(posts);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var user = await GetUserAsync();

        var model = new PostInputModel
        {
            CreatorId = user.Id
        };

        return View(model);
    }

    //ToDo: Fix the inputModel so its modelState becomes valid.
    [HttpPost]
    public async Task<IActionResult> Add(PostInputModel input)
    {
        if (!this.ModelState.IsValid)
        {
            return View(input);
        }

        await this.postsService.CreatePostAsync(input);

        return RedirectToAction("All", "Posts");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var postToEdit = await this.postsService.GetPostByIdAsync(id);

        if (postToEdit != null)
        {
            return View(postToEdit);
        }

        var postInputModel = new PostInputModel
        {
            Content = postToEdit!.Content,
            CreatorId = postToEdit.CreatorId,
            Title = postToEdit.Title
        };

        await this.postsService.UpdatePostAsync(postInputModel);

        return RedirectToAction("All", "Posts");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostInputModel input)
    {
        if (!this.ModelState.IsValid)
        {
            return View(new PostViewModel
            {
                Content = input.Content,
                Title = input.Title
            });
        }

        await this.postsService.UpdatePostAsync(input);

        return RedirectToAction("All", "Posts");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await this.postsService.DeletePostAsync(id);
        }
        catch (Exception)
        {
            return View("Error");
        }

        return RedirectToAction("All", "Posts");
    }

    private async Task<IdentityUser> GetUserAsync()
    => await this.userManager.GetUserAsync(this.HttpContext.User);
}