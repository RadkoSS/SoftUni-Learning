namespace Library.Data.Models.Entities;

using System.ComponentModel.DataAnnotations;

using static Common.Validation.CategoryConstants;

public class Category
{
    public Category()
    {
        this.Books = new HashSet<Book>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; }
}