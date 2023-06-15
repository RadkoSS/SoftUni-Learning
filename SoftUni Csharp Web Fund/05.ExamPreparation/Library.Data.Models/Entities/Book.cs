namespace Library.Data.Models.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.Validation.BookConstants;

public class Book
{
    public Book()
    {
        this.UsersBooks = new HashSet<IdentityUserBook>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(AuthorMaxLength)]
    public string Author { get; set; } = null!;

    [Required]
    [StringLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;

    [Required]
    public string ImageUrl { get; set; } = null!;

    [Required]
    public decimal Rating { get; set; }

    [Required]
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    [Required]
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<IdentityUserBook> UsersBooks { get; set; }
}