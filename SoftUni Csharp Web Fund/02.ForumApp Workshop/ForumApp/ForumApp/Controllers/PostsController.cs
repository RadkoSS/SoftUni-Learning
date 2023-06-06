// ReSharper disable InconsistentNaming
namespace ForumApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using ViewModels.Post;
using Services.Contracts;
using ViewModels;

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
    public async Task<IActionResult> All()
    {
        var posts = await postsService.GetAllPostsAsync();
        return View(posts);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(PostInputModel input)
    {
        var user = await userManager.GetUserAsync(HttpContext.User);

        input.CreatorId = user.Id;

        //if (!ModelState.IsValid)
        //{
        //    return View(input);
        //}

        await postsService.CreatePostAsync(input);

        return RedirectToAction("All", "Posts");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string postId)
    {
        var postToEdit = await postsService.GetPostByIdAsync(postId);

        return View(postToEdit);
        //try
        //{

        //}
        //catch (Exception e)
        //{
        //    return RedirectToAction("All", "Posts");
        //}
    }
}