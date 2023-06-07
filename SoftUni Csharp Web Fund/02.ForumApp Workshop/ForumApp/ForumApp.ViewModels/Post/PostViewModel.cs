namespace ForumApp.ViewModels.Post;

public class PostViewModel
{
    public string? PostId { get; set; }

    public string? CreatorId { get; set; }

    public string? CreatorName { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string? CreationDate { get; set; }
}