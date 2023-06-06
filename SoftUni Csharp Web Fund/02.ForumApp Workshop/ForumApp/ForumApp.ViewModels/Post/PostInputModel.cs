namespace ForumApp.ViewModels.Post;

using System.ComponentModel.DataAnnotations;

using static Common.Validations.PostConstants;

public class PostInputModel
{
    [Required]
    public string CreatorId { get; set; } = null!;

    [Required]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
    public string Title { get; set; } = null!;

    [Required]
    [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
    public string Content { get; set; } = null!;
}