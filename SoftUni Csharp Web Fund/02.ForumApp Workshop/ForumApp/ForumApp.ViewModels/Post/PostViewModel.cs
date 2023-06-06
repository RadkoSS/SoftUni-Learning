namespace ForumApp.ViewModels.Post;

public class PostViewModel
{
    public string PostId { get; set; } = string.Empty;

    public string CreatorId { get; set; } = null!;

    public string CreatorName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;
}