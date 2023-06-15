namespace Library.Services;

using Microsoft.EntityFrameworkCore;

using Data;
using Contracts;
using Data.Models.Entities;
using ViewModels.Book;
using ViewModels.Category;

public class BooksService : IBooksService
{
    private readonly LibraryDbContext dbContext;

    public BooksService(LibraryDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
    {
        var books = await this.dbContext.Books.AsNoTracking().Select(b => new BookViewModel
        {
            Id = b.Id,
            Author = b.Author,
            Title = b.Title,
            Category = b.Category.Name,
            Rating = b.Rating.ToString("f2"),
            ImageUrl = b.ImageUrl
        }).ToArrayAsync();

        return books;
    }

    public async Task<IEnumerable<BookViewModel>> GetUserBooksAsync(string userId)
    {
        var books = await this.dbContext.IdentityUserBooks.AsNoTracking().Where(ub => ub.CollectorId == userId).Select(ub => new BookViewModel
        {
            Id = ub.BookId,
            ImageUrl = ub.Book.ImageUrl,
            Category = ub.Book.Category.Name,
            Title = ub.Book.Title,
            Author = ub.Book.Author,
            Description = ub.Book.Description
        }).ToArrayAsync();

        return books;
    }

    public async Task AddBookToUserAsync(int bookId, string userId)
    {
        var isInUserCollection =
            await this.dbContext.IdentityUserBooks.AnyAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);

        if (!isInUserCollection)
        {
            await this.dbContext.IdentityUserBooks.AddAsync(new IdentityUserBook
            {
                BookId = bookId,
                CollectorId = userId
            });

            await this.dbContext.SaveChangesAsync();
        }
    }

    public async Task RemoveBookFromUserAsync(int bookId, string userId)
    {
        var isInUserCollection =
            await this.dbContext.IdentityUserBooks.AnyAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);

        if (isInUserCollection)
        {
            var bookToRemove = await this.dbContext.IdentityUserBooks.FirstAsync(ub => ub.BookId == bookId && ub.CollectorId == userId);

            this.dbContext.IdentityUserBooks.Remove(bookToRemove);

            await this.dbContext.SaveChangesAsync();
        }
    }

    public async Task<CategoryViewModel[]> GetCategoriesAsync()
    {
        var categories = await this.dbContext.Categories.AsNoTracking().Select(c => new CategoryViewModel
        {
            Id = c.Id,
            Name = c.Name,
        }).ToArrayAsync();

        return categories;
    }

    public async Task CreateBookAsync(AddBookInputModel input)
    {
        var category = await this.dbContext.Categories.FirstOrDefaultAsync(c => c.Id == input.CategoryId);

        if (category != null)
        {
            var book = new Book
            {
                CategoryId = category.Id,
                Author = input.Author,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Rating = decimal.Parse(input.Rating),
                Title = input.Title,
            };

            await this.dbContext.Books.AddAsync(book);

            await this.dbContext.SaveChangesAsync();
        }
    }
}