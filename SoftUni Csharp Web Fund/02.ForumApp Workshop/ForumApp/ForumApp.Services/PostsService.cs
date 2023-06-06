namespace ForumApp.Services;

// ReSharper disable once InconsistentNaming
using Contracts;
using Microsoft.EntityFrameworkCore;

using Data;
using Data.Models;
using ViewModels.Post;

public class PostsService : IPostsService
{
    private readonly ApplicationDbContext context;

    public PostsService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<PostViewModel[]> GetAllPostsAsync()
    => await context.Posts.AsNoTracking().Select(p => new PostViewModel
    {
        PostId = p.Id.ToString(),
        Title = p.Title,
        Content = p.Content,
        CreatorId = p.CreatorId,
        CreatorName = p.Creator.UserName
    }).ToArrayAsync();

    public async Task<PostViewModel> GetPostByIdAsync(string postId)
    {
        var result = await context.Posts.Where(p => p.Id.ToString() == postId).Select(p => new PostViewModel
        {
            PostId = p.Id.ToString(),
            Title = p.Title,
            Content = p.Content,
            CreatorId = p.CreatorId,
            CreatorName = p.Creator.UserName
        }).FirstAsync();
        
        return result;
    }
    public async Task CreatePostAsync(PostInputModel model)
    {
        await context.Posts.AddAsync(new Post
        {
            CreatorId = model.CreatorId,
            Title = model.Title,
            Content = model.Content
        });

        await context.SaveChangesAsync();
    }
}