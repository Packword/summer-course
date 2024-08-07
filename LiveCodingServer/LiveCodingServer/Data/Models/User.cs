namespace LiveCodingServer.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Post> Posts { get; set; }
}