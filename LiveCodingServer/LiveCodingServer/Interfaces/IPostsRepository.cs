using LiveCodingServer.Models;

namespace LiveCodingServer.Interfaces;

public interface IPostsRepository
{
    public IEnumerable<Post> GetAll();
    public Post? GetById(Guid id);
    public Task<Post> AddAsync(PostRequest request);
}