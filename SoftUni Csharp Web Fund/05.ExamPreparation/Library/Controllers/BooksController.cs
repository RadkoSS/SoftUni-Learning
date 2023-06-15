namespace Library.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using ViewModels.Book;
using Services.Contracts;

using static Common.Validation.BookConstants;

public class BooksController : BaseController
{
    private readonly IBooksService booksService;
    private readonly UserManager<IdentityUser> userManager;

    public BooksController(IBooksService booksService, UserManager<IdentityUser> userManager)
    {
        this.booksService = booksService;
        this.userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var books = await this.booksService.GetAllBooksAsync();

        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> Mine()
    {
        var userId = GetUserId();

        var books = await this.booksService.GetUserBooksAsync(userId);

        return View(books);
    }
    
    public async Task<IActionResult> AddToCollection(string bookId)
    {
        if (int.TryParse(bookId, out int bookIdAsNumber))
        {
            await this.booksService.AddBookToUserAsync(bookIdAsNumber, GetUserId());
        }
        
        return RedirectToAction("All", "Books");
    }

    public async Task<IActionResult> RemoveFromCollection(string bookId)
    {
        if (int.TryParse(bookId, out int bookIdAsNumber))
        {
            await this.booksService.RemoveBookFromUserAsync(bookIdAsNumber, GetUserId());
        }

        return RedirectToAction("Mine", "Books");
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = new AddBookViewModel
        {
            Categories = await this.booksService.GetCategoriesAsync()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddBookInputModel input)
    {
        if (!ModelState.IsValid || !decimal.TryParse(input.Rating, out decimal rating) || rating < RatingMinValue || rating > RatingMaxValue)
        {
            ModelState.AddModelError(input.Rating, "Invalid data provided.");

            input.Categories = await this.booksService.GetCategoriesAsync();
            return View(input);
        }

        await this.booksService.CreateBookAsync(input);

        return RedirectToAction("All", "Books");
    }

    private string GetUserId()
        => this.userManager.GetUserId(User);
}