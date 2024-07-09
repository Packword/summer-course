using LiveCodingServer.Data;
using LiveCodingServer.Interfaces;
using LiveCodingServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveCodingServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IPostsRepository _postsRepository;
    private readonly ApplicationDbContext _db;

    public PostsController(IPostsRepository postsRepository, ApplicationDbContext db)
    {
        _postsRepository = postsRepository;
        _db = db;
    }
    
    [HttpGet] 
    public IActionResult Get()
    {
        var posts = _postsRepository.GetAll();
        if (!posts.Any())
            NotFound();
        return Ok(posts);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostRequest post)
    {
        var newPost = await _postsRepository.AddAsync(post);
        
        return Ok(newPost);
    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetById(Guid id)
    {
        var post = _postsRepository.GetById(id);
        if (post is null)
        {
            return NotFound();
        }

        return Ok(post);
    }
}