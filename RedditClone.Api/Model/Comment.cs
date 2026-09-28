using System.Text.Json.Serialization;


    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int Votes { get; set; } = 0;

       

       
    }
