using LiveCodingServer.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveCodingServer.Data;

public class ApplicationDbContext: DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var user = new User
        {
            Id = Guid.NewGuid(),
            Name = "Maxim"
        };

        modelBuilder.Entity<User>().HasData(user);
        
        modelBuilder.Entity<Post>().HasData(
            
            new Post
            {
                Body = "123456",
                Title = "098765432",
                UserId = user.Id
            }
        );
    }
}