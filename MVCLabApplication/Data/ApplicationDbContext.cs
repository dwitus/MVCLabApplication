using Microsoft.EntityFrameworkCore;
using MVCLabApplication.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Electronics" },
            new Category { CategoryId = 2, Name = "Clothing" }
        // Add more categories as needed
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Laptop", Price = 999.99M, CategoryId = 1 },
            new Product { ProductId = 2, Name = "T-Shirt", Price = 19.99M, CategoryId = 2 }
        // Add more products as needed
        );

        modelBuilder.Entity<Product>()
        .Property(p => p.Price)
        .HasColumnType("decimal(18, 2)");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}