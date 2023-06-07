namespace ForumApp.ViewModels.Post;

public class AllPostsViewModel
{
    public string? CurrentUserId { get; set; }

    public PostViewModel[] Posts { get; set; } = null!;
}