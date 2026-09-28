using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("PostContext")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
