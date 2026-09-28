using System.Text.Json.Serialization;

namespace Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int Votes { get; set; } = 0;

        public int PostId { get; set; }

        [JsonIgnore]
        public Post? Post { get; set; }
    }
}