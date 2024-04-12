using Microsoft.EntityFrameworkCore;
using StockApp.Models;

namespace StockApp.Data;

public class StockDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = $"Server=localhost;Database=StockApp;User Id=admin;Password=admin;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connectionString);
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
