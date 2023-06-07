namespace ForumApp.Services;

// ReSharper disable once InconsistentNaming
using Microsoft.EntityFrameworkCore;

using Data;
using Contracts;
using Data.Models;
using ViewModels.Post;

public class PostsService : IPostsService
{
    private readonly ApplicationDbContext context;

    public PostsService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<AllPostsViewModel> GetAllPostsAsync(string? userId)
    {
        var posts = await this.context.Posts.AsNoTracking().Select(p => new PostViewModel
        {
            PostId = p.Id.ToString(),
            Title = p.Title,
            Content = p.Content,
            CreatorId = p.CreatorId,
            CreatorName = p.Creator.UserName,
            CreationDate = p.CreationDate.ToString("d")
        }).ToArrayAsync();

        var allPostsViewModel = new AllPostsViewModel
        {
            CurrentUserId = userId,
            Posts = posts
        };

        return allPostsViewModel;
    }
    
    public async Task<PostViewModel?> GetPostByIdAsync(string id)
    {
        var resultAsEntities = await this.context.Posts.Where(p => p.Id.ToString() == id).ToListAsync();

        var result = resultAsEntities.Select(p => new PostViewModel
        {
            PostId = p.Id.ToString(),
            Title = p.Title,
            Content = p.Content,
            CreatorId = p.CreatorId,
            CreatorName = p.Creator.UserName
        }).FirstOrDefault();

        return result;
    }

    public async Task CreatePostAsync(PostInputModel model)
    {
        await this.context.Posts.AddAsync(new Post
        {
            CreatorId = model.CreatorId,
            Title = model.Title,
            Content = model.Content
        });

        await this.context.SaveChangesAsync();
    }

    public async Task UpdatePostAsync(PostInputModel model)
    {
        await this.context.Posts.AddAsync(new Post
        {
            CreatorId = model.CreatorId,
            Title = model.Title,
            Content = model.Content
        });

        await this.context.SaveChangesAsync();
    }

    public async Task DeletePostAsync(string postId)
    {
        var postToDelete = await this.context.Posts.FirstAsync(p => p.Id.ToString() == postId);

        this.context.Posts.Remove(postToDelete);

        await this.context.SaveChangesAsync();
    }
}