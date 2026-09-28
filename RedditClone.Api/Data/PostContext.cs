using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

public class PostContext : DbContext
    {
        public DbSet<Post> Posts => Set<Post>();
        public string DbPath { get; set; }

    public PostContext()
    {
        DbPath = "bin/Post.db";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite($"Data Source={DbPath}");
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().ToTable("Posts");

    }
}

