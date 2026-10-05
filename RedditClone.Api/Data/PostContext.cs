using Microsoft.EntityFrameworkCore;
using shared.Model;
public class PostContext : DbContext
{
    public PostContext(DbContextOptions<PostContext> options) : base(options) { }

    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<User> Users => Set<User>();
}

