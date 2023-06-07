namespace ForumApp.Data.Models;

using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.Validations.PostConstants;

public class Post
{
    public Post()
    {
        this.Id = Guid.NewGuid();
        this.CreationDate = DateTime.Now.ToLocalTime();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLength)]
    public string Content { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Creator))]
    public string CreatorId { get; set; } = null!;

    [Required]
    public virtual IdentityUser Creator { get; set; } = null!;

    [Required]
    public DateTime CreationDate { get; set; }
}