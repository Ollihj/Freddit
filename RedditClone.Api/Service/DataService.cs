
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

public class DataService
    {

    private PostContext db { get; }

    public DataService(PostContext db)
    {
        this.db = db;
    }
    
    public void SeedData()
    {
        Comment comment1 = new Comment { Author = "Kristian", CommentId = Random.Shared.Next(1, 10000000), Text = "Du er gay" };
        List<Comment> comments = new List<Comment>();
        comments.Add(comment1);
        Post post = db.Posts.FirstOrDefault()!;

        if (post == null)
        {
            post = new Post
            {
                Title = "Southpark season 29",
                Author = "Oliver",
                Comments = comments,
                PostId = Random.Shared.Next(1, 10000000),
                Text = "Den nye sæson af Southpark er virkelig god",

            };
            db.Posts.Add(post);
        }
        db.SaveChanges();
    }
    public List<Post> GetPosts()
    {
        return db.Posts.Include(b => b.Comments).ToList();
    }
    }

