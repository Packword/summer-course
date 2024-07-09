using System.Text.Json;
using LiveCodingServer.Data;
using LiveCodingServer.Interfaces;
using LiveCodingServer.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveCodingServer.Services;

public class PostsRepository: IPostsRepository
{
    private readonly ApplicationDbContext _db;

    public PostsRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Post> GetAll()
        => _db.Posts.Include(p => p.User);

    public Post? GetById(Guid id) 
        => _db.Posts.FirstOrDefault(p => p.Id == id);

     public async Task<Post> AddAsync(PostRequest request)
    {
        var newPost = new Post
        {
            Body = request.Body,
            Title = request.Title
        };
        _db.Posts.Add(newPost);

        await _db.SaveChangesAsync();
        return newPost;
    }
}