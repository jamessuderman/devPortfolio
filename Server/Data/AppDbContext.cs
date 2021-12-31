using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var categoriesToSeed = new Category[3];

        for (int i = 1; i < 4; i++)
        {
            categoriesToSeed[i - 1] = new Category
            {
                CategoryId = i,
                ThumbnailImagePath = "uploads/placeholder.jpg",
                Name = $"Category {i}",
                Description = $"A description for category {i}"
            };
        }

        modelBuilder.Entity<Category>().HasData(categoriesToSeed);
    }
    
    private DbSet<Category> Categories { get; set; }
}