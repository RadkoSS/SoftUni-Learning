namespace ForumApp.Services.Contracts;

using ViewModels.Post;

public interface IPostsService
{
    Task<AllPostsViewModel> GetAllPostsAsync(string? userId);

    Task<PostViewModel?> GetPostByIdAsync(string postId);

    Task CreatePostAsync(PostInputModel model);

    Task UpdatePostAsync(PostInputModel model);

    Task DeletePostAsync(string postId);
}