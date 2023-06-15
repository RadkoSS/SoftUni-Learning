namespace Library.ViewModels.Book;

using System.ComponentModel.DataAnnotations;

using static Common.Validation.BookConstants;

public class AddBookInputModel : AddBookViewModel
{
    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public new string Title { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
    public new string Description { get; set; } = null!;

    [Required]
    [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
    public new string Author { get; set; } = null!;

    [Required]
    public new string ImageUrl { get; set; } = null!;

    [Required]
    public new string Rating { get; set; } = null!;

    [Required]
    [Range(1, int.MaxValue)]
    public new int CategoryId { get; set; }
}