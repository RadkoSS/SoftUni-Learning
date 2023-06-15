namespace Library.Services.Contracts;

using ViewModels.Book;
using ViewModels.Category;

public interface IBooksService
{
    Task<IEnumerable<BookViewModel>> GetAllBooksAsync();

    Task<IEnumerable<BookViewModel>> GetUserBooksAsync(string userId);

    Task AddBookToUserAsync(int bookId, string userId);

    Task RemoveBookFromUserAsync(int bookId, string userId);

    Task<CategoryViewModel[]> GetCategoriesAsync();

    Task CreateBookAsync(AddBookInputModel input);
}