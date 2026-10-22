using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using shared.Model;
var builder = WebApplication.CreateBuilder(args);

var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSomeStuff, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<PostContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PostContext")));

builder.Services.AddScoped<DataService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
    dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}


app.UseHttpsRedirection();
app.UseCors(AllowSomeStuff);

app.Use(async (context, next) =>
{
    context.Response.ContentType = "application/json; charset=utf-8";
    await next(context);
});

app.MapGet("/api/posts", (DataService service) =>
{
    return service.GetPosts();
});
app.MapPut("/api/posts/{id}/upvote", (int id, DataService service) =>
{
    return service.UpvotePost(id);
});
app.MapPut("/api/posts/{id}/downvote", (int id, DataService service) =>
{
    return service.DownvotePost(id);
});

app.MapPost("/api/posts", (NewPostData data, DataService service) =>
{
    return service.CreatePost(data.Title, data.Text, data.Url, data.Username);
});
app.MapPost("/api/posts/{id}/comments", (int id, NewCommentData data, DataService service) =>
{
    var comment = service.CreateComment(data.Content, data.Username, id);
    return comment is null ? Results.NotFound() : Results.Ok(comment);
});
app.Run();

record NewPostData(string Title, string? Text, string? Url, string Username);
record NewCommentData(string Content, string Username);
