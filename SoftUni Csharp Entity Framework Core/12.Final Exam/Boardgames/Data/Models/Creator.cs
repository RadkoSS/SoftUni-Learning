namespace Boardgames.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Creator
{
    public Creator()
    {
        this.Boardgames = new HashSet<Boardgame>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(ValidationConstants.CreatorFirstNameMaxLength)]
    public string FirstName { get; set; } = null!;

    [Required]
    [StringLength(ValidationConstants.CreatorLastNameMaxLength)]
    public string LastName { get; set; } = null!;

    public virtual ICollection<Boardgame> Boardgames { get; set; }
}