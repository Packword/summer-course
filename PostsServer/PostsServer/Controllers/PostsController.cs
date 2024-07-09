using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using PostsServer.Models;

namespace PostsServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private const string FilePath = "posts.json";
    private readonly JsonSerializerOptions _options = new (){ PropertyNameCaseInsensitive = true };
    
    [HttpGet]
    public IActionResult Get()
    {
        if (!System.IO.File.Exists(FilePath))
        {
            return NotFound("The posts file does not exist.");
        }

        var jsonData = System.IO.File.ReadAllText(FilePath);
        var posts = JsonSerializer.Deserialize<List<Post>>(jsonData, _options);
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        if (!System.IO.File.Exists(FilePath))
        {
            return NotFound("The posts file does not exist.");
        }

        var jsonData = System.IO.File.ReadAllText(FilePath);
        var posts = JsonSerializer.Deserialize<List<Post>>(jsonData, _options);
        var post = posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return NotFound("Post not found.");
        }
        return Ok(post);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Post newPost)
    {
        if (!System.IO.File.Exists(FilePath))
        {
            return NotFound("The posts file does not exist.");
        }

        var jsonData = System.IO.File.ReadAllText(FilePath);
        var posts = JsonSerializer.Deserialize<List<Post>>(jsonData, _options);
        newPost.Id = posts.Any() ? posts.Max(p => p.Id) + 1 : 1;
        posts.Add(newPost);
        System.IO.File.WriteAllText(FilePath, JsonSerializer.Serialize(posts, new JsonSerializerOptions { WriteIndented = true }));
        return CreatedAtAction(nameof(Get), new { id = newPost.Id }, newPost);
    }
}
