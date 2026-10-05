
using Microsoft.EntityFrameworkCore;
using shared.Model;

public class DataService
    {

    private PostContext db { get; }

    public DataService(PostContext db)
    {
        this.db = db;
    }
    
    public void SeedData()
    {
        Post post = db.Posts.FirstOrDefault()!;

        if (post == null)
        {
            User kristian = new User("Kristian");
            User oliver = new User("Oliver");
            db.Users.AddRange(kristian, oliver);

            Comment comment1 = new Comment("Du er gay", 0, 0, kristian);

            post = new Post(oliver, "Southpark season 29", "Den nye sæson af Southpark er virkelig god");
            post.Comments.Add(comment1);

            db.Posts.Add(post);
        }
        db.SaveChanges();
    }
    public List<Post> GetPosts()
    {
        return db.Posts
            .Include(p => p.User)
            .Include(p => p.Comments).ThenInclude(c => c.User)
            .ToList();
    }
    public Post? UpvotePost(int id)
    {
        var post = db.Posts.FirstOrDefault(x => x.Id == id);
        if (post == null)
        {
            return null;
        }
        post.Upvotes++;
        db.SaveChanges();
        return post;
    }

    public Post? DownvotePost(int id)
    {
        var post = db.Posts.FirstOrDefault(x => x.Id == id);
        if (post == null)
        {
            return null;
        }
        post.Downvotes++;
        db.SaveChanges();
        return post;
    }

    public Post CreatePost(string title, string content, string sername)
    {
        User newUser = new User(sername);
        Post newPost = new Post(newUser, title, content);
        db.Posts.Add(newPost);
        db.SaveChanges();
        return newPost;
    }
    public Comment CreateComment(string content, string username,int id)
    {
        User newUser = new User(username);
        Comment NewComment = new Comment(content, 0, 0, newUser);
        var post = db.Posts.FirstOrDefault(x => x.Id == id);
        post.Comments.Add(NewComment);
        db.SaveChanges();
        return NewComment;
    }
}
