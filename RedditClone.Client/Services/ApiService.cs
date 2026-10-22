using System.Net.Http.Json;
using shared.Model;

namespace RedditClone.Client.Services;

public class ApiService
{
    private readonly HttpClient http;

    public ApiService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<List<Post>> GetPosts()
    {
        return await http.GetFromJsonAsync<List<Post>>("posts") ?? new List<Post>();
    }

    public async Task<Post?> GetPost(int id)
    {
        var response = await http.GetAsync($"posts/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<Post>();
    }

    public async Task<Post?> CreatePost(string title, string? text, string? url, string username)
    {
        var response = await http.PostAsJsonAsync("posts", new { Title = title, Text = text, Url = url, Username = username });
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<Post>();
    }

    public async Task<Comment?> CreateComment(int postId, string content, string username)
    {
        var response = await http.PostAsJsonAsync($"posts/{postId}/comments", new { Content = content, Username = username });
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<Post?> UpvotePost(int id)
    {
        var response = await http.PutAsync($"posts/{id}/upvote", null);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<Post>();
    }

    public async Task<Post?> DownvotePost(int id)
    {
        var response = await http.PutAsync($"posts/{id}/downvote", null);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<Post>();
    }

    public async Task<Comment?> UpvoteComment(int postId, int commentId)
    {
        var response = await http.PutAsync($"posts/{postId}/comments/{commentId}/upvote", null);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<Comment>();
    }

    public async Task<Comment?> DownvoteComment(int postId, int commentId)
    {
        var response = await http.PutAsync($"posts/{postId}/comments/{commentId}/downvote", null);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<Comment>();
    }
}
