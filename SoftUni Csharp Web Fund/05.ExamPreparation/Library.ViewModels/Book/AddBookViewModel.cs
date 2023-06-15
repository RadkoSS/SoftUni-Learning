namespace Library.ViewModels.Book;

using Category;

public class AddBookViewModel
{
    public AddBookViewModel()
    {
        this.Categories = new HashSet<CategoryViewModel>();
    }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Author { get; set; }

    public string? ImageUrl { get; set; }

    public string? Rating { get; set; }

    public int? CategoryId { get; set; }

    public IEnumerable<CategoryViewModel> Categories { get; set; }
}