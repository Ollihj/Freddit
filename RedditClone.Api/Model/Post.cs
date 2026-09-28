
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }   // enten Text...
        public string? Url { get; set; }    // ...eller Url
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int Votes { get; set; } = 0;

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
