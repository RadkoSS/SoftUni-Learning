namespace ForumApp.Services.Contracts;

using ViewModels.Post;

public interface IPostsService
{
    Task<PostViewModel[]> GetAllPostsAsync();

    Task<PostViewModel> GetPostByIdAsync(string postId);

    Task CreatePostAsync(PostInputModel model);
}