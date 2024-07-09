namespace LiveCodingServer.Models;

public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Body { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}